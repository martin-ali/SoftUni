using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(configuration => configuration.AddProfile<CarDealerProfile>());

            var context = new CarDealerContext();
            // context.Database.EnsureDeleted();
            // context.Database.EnsureCreated();

            // var suppliersData = File.ReadAllText("Datasets/suppliers.json");
            // Console.WriteLine(ImportSuppliers(context, suppliersData));

            // var partsData = File.ReadAllText("Datasets/parts.json");
            // Console.WriteLine(ImportParts(context, partsData));

            // var carsData = File.ReadAllText("Datasets/cars.json");
            // Console.WriteLine(ImportCars(context, carsData));

            // var customersData = File.ReadAllText("Datasets/customers.json");
            // Console.WriteLine(ImportCustomers(context, customersData));

            // var salesData = File.ReadAllText("Datasets/sales.json");
            // Console.WriteLine(ImportSales(context, salesData));

            Console.WriteLine(GetOrderedCustomers(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                        .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                        .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<List<CarImportDto>>(inputJson);

            var cars = Mapper.Map<List<Car>>(carDtos);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                            .OrderBy(c => c.BirthDate)
                            .ThenBy(c => c.IsYoungDriver == false)
                            .Select(c => new
                            {
                                c.Name,
                                BirthDate = $"{c.BirthDate.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}",
                                c.IsYoungDriver
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(customers);
            return resultsJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                            .Where(c => c.Make == "Toyota")
                            .OrderBy(c => c.Model)
                            .ThenByDescending(c => c.TravelledDistance)
                            .Select(c => new
                            {
                                c.Id,
                                c.Make,
                                c.Model,
                                c.TravelledDistance
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(cars);
            return resultsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(s => new
                            {
                                s.Id,
                                s.Name,
                                PartsCount = s.Parts.Count
                                // PartsCount = s.Parts.Sum(p=>p.Quantity)
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(suppliers);
            return resultsJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                            .Select(c => new
                            {
                                car = new
                                {
                                    c.Make,
                                    c.Model,
                                    c.TravelledDistance
                                },
                                parts = c.PartCars
                                        .Select(p => new
                                        {
                                            p.Part.Name,
                                            Price = $"{p.Part.Price}:0.00"
                                        })
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include
            });
            return resultsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                            .Where(c => c.Sales.Count >= 1)
                            .OrderByDescending(c => c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price)))
                            .ThenByDescending(c => c.Sales.Count)
                            .Select(c => new
                            {
                                fullName = c.Name,
                                boughtCars = c.Sales.Count,
                                spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(customers);
            return resultsJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                        .Take(10)
                        .Select(s => new
                        {
                            car = new
                            {
                                s.Car.Make,
                                s.Car.Model,
                                s.Car.TravelledDistance
                            },
                            customerName = s.Customer.Name,
                            Discount = $"{s.Discount:0.00}",
                            price = $"{s.Car.PartCars.Sum(p => p.Part.Price):0.00}",
                            // Looks horrible, but should be in the query?
                            priceWithDiscount = $"{s.Car.PartCars.Distinct().Sum(p => p.Part.Price) - (s.Car.PartCars.Distinct().Sum(p => p.Part.Price) * s.Discount / 100):0.00}"
                        })
                        .ToList();

            var resultsJson = JsonConvert.SerializeObject(sales);
            return resultsJson;
        }
    }
}