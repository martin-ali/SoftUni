using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(configuration => configuration.AddProfile<ProductShopProfile>());
            var context = new ProductShopContext();
            // context.Database.EnsureDeleted();
            // context.Database.EnsureCreated();

            using (context)
            {
                // var importUsersResult = ImportUsers(context, File.ReadAllText("./Datasets/users.xml"));
                // Console.WriteLine(importUsersResult);

                // var importProductsResult = ImportProducts(context, File.ReadAllText("./Datasets/products.xml"));
                // Console.WriteLine(importProductsResult);

                // var importCategoriesResult = ImportCategories(context, File.ReadAllText("./Datasets/categories.xml"));
                // Console.WriteLine(importCategoriesResult);

                // var importCategoryProductsResult = ImportCategoryProducts(context, File.ReadAllText("./Datasets/categories-products.xml"));
                // Console.WriteLine(importCategoryProductsResult);

                Console.WriteLine(GetCategoriesByProductsCount(context));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportUserDto>),
                                                new XmlRootAttribute("Users"));

            var userDtos = (List<ImportUserDto>)serializer.Deserialize(new StringReader(inputXml));
            var users = Mapper.Map<List<User>>(userDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportProductDto>),
                                                new XmlRootAttribute("Products"));

            var productDtos = (List<ImportProductDto>)serializer.Deserialize(new StringReader(inputXml));
            var products = Mapper.Map<List<Product>>(productDtos);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategoryDto>),
                                                new XmlRootAttribute("Categories"));

            var categoryDtos = (List<ImportCategoryDto>)serializer.Deserialize(new StringReader(inputXml));
            var categories = Mapper.Map<List<Category>>(categoryDtos)
                                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>),
                                                new XmlRootAttribute("CategoryProducts"));

            var categoryIds = context.Categories.Select(c => c.Id);
            var productIds = context.Products.Select(p => p.Id);
            var categoryProductDtos = (List<ImportCategoryProductDto>)serializer.Deserialize(new StringReader(inputXml));
            var categoryProducts = Mapper.Map<List<CategoryProduct>>(categoryProductDtos)
                                    .Where(cp => categoryIds.Contains(cp.CategoryId))
                                    .Where(cp => productIds.Contains(cp.ProductId));

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context.Products
                            .Where(p => 500 <= p.Price && p.Price <= 1000)
                            .OrderBy(p => p.Price)
                            .Take(10)
                            .ProjectTo<ExportProductDto>()
                            .ToList();

            var serializer = new XmlSerializer(result.GetType(),
                                                new XmlRootAttribute("Products"));

            var resultXml = new StringBuilder();
            var writer = new StringWriter(resultXml);
            using (writer)
            {
                serializer.Serialize(writer, result);
            }

            return resultXml.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = context.Users
                            .Where(u => u.ProductsSold.Count >= 1)
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Take(5)
                            .ProjectTo<ExportUserDto>()
                            .ToList();

            var serializer = new XmlSerializer(result.GetType(),
                                                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var resultXml = new StringBuilder();
            var writer = new StringWriter(resultXml);
            using (writer)
            {
                serializer.Serialize(writer, result, namespaces);
            }

            return resultXml.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = context.Categories
                            .OrderByDescending(c => c.CategoryProducts.Count)
                            .ProjectTo<ExportCategoryDto>()
                            .ToList();

            var serializer = new XmlSerializer(result.GetType(),
                                                new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var resultXml = new StringBuilder();
            var writer = new StringWriter(resultXml);
            using (writer)
            {
                serializer.Serialize(writer, result, namespaces);
            }

            return resultXml.ToString();
        }
    }
}