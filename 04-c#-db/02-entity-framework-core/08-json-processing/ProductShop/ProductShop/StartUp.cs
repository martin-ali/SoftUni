using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var usersData = File.ReadAllText("Datasets/users.json");
            Console.WriteLine(ImportUsers(context, usersData));

            var productsData = File.ReadAllText("Datasets/products.json");
            Console.WriteLine(ImportProducts(context, productsData));

            var categoriesData = File.ReadAllText("Datasets/categories.json");
            Console.WriteLine(ImportCategories(context, categoriesData));

            var categoryProductsData = File.ReadAllText("Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, categoryProductsData));

            // Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = $"Successfully imported {users.Count}";
            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            var result = $"Successfully imported {products.Count}";
            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var result = $"Successfully imported {categories.Count()}";
            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            var result = $"Successfully imported {categoryProducts.Count}";
            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                            .Where(p => 500 <= p.Price && p.Price <= 1000)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price,
                                seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(products, Formatting.None);
            return resultsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                soldProducts = u.ProductsSold
                                                .Select(p => new
                                                {
                                                    name = p.Name,
                                                    price = p.Price,
                                                    buyerFirstName = p.Buyer.FirstName,
                                                    buyerLastName = p.Buyer.LastName
                                                })
                            })
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(users, Formatting.None);
            return resultsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                            .OrderByDescending(c => c.CategoryProducts.Count)
                            .Select(c => new
                            {
                                category = c.Name,
                                productsCount = c.CategoryProducts.Count,
                                averagePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):0.00}",
                                totalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):0.00}"
                            })
                            .OrderByDescending(c => c.productsCount)
                            .ToList();

            var resultsJson = JsonConvert.SerializeObject(categories, Formatting.None);
            return resultsJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                            .OrderByDescending(u => u.ProductsSold
                                                        .Count(p => p.Buyer != null))
                            .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                age = u.Age,
                                soldProducts = new
                                {
                                    count = u.ProductsSold.Count(p => p.Buyer != null),
                                    products = u.ProductsSold
                                                .Where(p => p.Buyer != null)
                                                .Select(ps => new
                                                {
                                                    name = ps.Name,
                                                    price = ps.Price
                                                })
                                }
                            })
                            .ToList();

            var statistics = new
            {
                usersCount = users.Count,
                users
            };

            var resultsJson = JsonConvert.SerializeObject(statistics, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            // File.WriteAllText("tester.json", resultsJson);

            return resultsJson;
        }
    }
}