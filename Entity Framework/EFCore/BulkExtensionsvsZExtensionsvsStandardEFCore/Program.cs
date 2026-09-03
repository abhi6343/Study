using BulkExtensionsvsZExtensionsvsStandardEFCore.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace BulkExtensionsvsZExtensionsvsStandardEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var context = new EFCoreDbContext();
            //// Generate the products
            //var products = GenerateProducts(2000);
            //// Standard EF Core Insert
            //var efCoreTime = InsertWithStandardEFCore(products);
            //// Z.EntityFramework.Extensions.EFCore Insert
            //var zEntityExtensionsTime = InsertWithZEntityExtensions(products);
            //// EFCore.BulkExtensions Insert
            //var bulkExtensionsTime = InsertWithEFCoreBulkExtensions(products);
            //// Display the results
            //Console.WriteLine("\nBulk Insert Performance Benchmark:");
            //Console.WriteLine($"Standard EF Core Insert: {efCoreTime} ms");
            //Console.WriteLine($"Z.EntityFramework.Extensions.EFCore Insert: {zEntityExtensionsTime} ms");
            //Console.WriteLine($"EFCore.BulkExtensions Insert: {bulkExtensionsTime} ms");




            // Standard EF Core Update
            var efCoreUpdateTime = UpdateWithStandardEFCore();
            // Z.EntityFramework.Extensions.EFCore Update
            var zEntityExtensionsUpdateTime = UpdateWithZEntityExtensions();
            // EFCore.BulkExtensions Update
            var bulkExtensionsUpdateTime = UpdateWithEFCoreBulkExtensions();
            // Display the results
            Console.WriteLine("\nBulk Update Performance Benchmark:");
            Console.WriteLine($"Standard EF Core Update: {efCoreUpdateTime} ms");
            Console.WriteLine($"Z.EntityFramework.Extensions.EFCore Update: {zEntityExtensionsUpdateTime} ms");
            Console.WriteLine($"EFCore.BulkExtensions Update: {bulkExtensionsUpdateTime} ms");





            // Generate initial products and insert them into the database
            var initialProducts1 = GenerateProducts(2000);
            var initialProducts2 = GenerateProducts(2000);
            var initialProducts3 = GenerateProducts(2000);
            // Ensure the data is pre-inserted
            InsertWithStandardEFCore(initialProducts1);
            InsertWithStandardEFCore(initialProducts2);
            InsertWithStandardEFCore(initialProducts3);
            // Standard EF Core Delete
            var efCoreDeleteTime = DeleteWithStandardEFCore(initialProducts1);
            // Z.EntityFramework.Extensions.EFCore Delete
            var zEntityExtensionsDeleteTime = DeleteWithZEntityExtensions(initialProducts2);
            // EFCore.BulkExtensions Delete
            var bulkExtensionsDeleteTime = DeleteWithEFCoreBulkExtensions(initialProducts3);
            // Display the results
            Console.WriteLine("\nBulk Delete Performance Benchmark:");
            Console.WriteLine($"Standard EF Core Delete: {efCoreDeleteTime} ms");
            Console.WriteLine($"Z.EntityFramework.Extensions.EFCore Delete: {zEntityExtensionsDeleteTime} ms");
            Console.WriteLine($"EFCore.BulkExtensions Delete: {bulkExtensionsDeleteTime} ms");
        }
        // Generates a list of Product instances.
        static List<Product> GenerateProducts(int count)
        {
            var products = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                products.Add(new Product
                {
                    Name = $"Product_{i}",
                    Price = (decimal)(new Random().NextDouble() * 100),
                    Quantity = 100,
                    Description = $"Product_{i} Description",
                    CreatedDate = DateTime.Now,
                    IsAvailable = true,
                    ModifiedBy = "Admin"
                });
            }
            return products;
        }
        // Inserts products using standard EF Core AddRange and SaveChanges.
        static long InsertWithStandardEFCore(List<Product> products)
        {
            using (var context = new EFCoreDbContext())
            {
                var stopwatch = Stopwatch.StartNew();
                context.Products.AddRange(products);
                context.SaveChanges();
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Deletes products using standard EF Core RemoveRange and SaveChanges.
        static long DeleteWithStandardEFCore(List<Product> products)
        {
            using (var context = new EFCoreDbContext())
            {
                var stopwatch = Stopwatch.StartNew();
                context.Products.RemoveRange(products); // Delete using standard EF Core
                context.SaveChanges();
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Deletes products using EFCore.BulkExtensions BulkDelete.
        static long DeleteWithEFCoreBulkExtensions(List<Product> products)
        {
            using (var context = new EFCoreDbContext())
            {
                var stopwatch = Stopwatch.StartNew();
                // Bulk delete using EFCore.BulkExtensions
                EFCore.BulkExtensions.DbContextBulkExtensions.BulkDelete(context, products);
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Deletes products using Z.EntityFramework.Extensions.EFCore BulkDelete.
        static long DeleteWithZEntityExtensions(List<Product> products)
        {
            using (var context = new EFCoreDbContext())
            {
                var stopwatch = Stopwatch.StartNew();
                // Bulk delete using Z.EntityFramework.Extensions
                DbContextExtensions.BulkDelete(context, products);
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Generates a list of Product instances.
        //static List<Product> GenerateProducts(int count)
        //{
        //    var products = new List<Product>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        products.Add(new Product
        //        {
        //            Name = $"Product_{i}",
        //            Price = (decimal)(new Random().NextDouble() * 100),
        //            Quantity = 100,
        //            Description = $"Product_{i} Description",
        //            CreatedDate = DateTime.Now,
        //            IsAvailable = true,
        //            ModifiedBy = "Admin"
        //        });
        //    }
        //    return products;
        //}
        // Inserts products using standard EF Core AddRange and SaveChanges.
        //static void InsertWithStandardEFCore(List<Product> products)
        //{
        //    using (var context = new EFCoreDbContext())
        //    {
        //        //Then add new data
        //        context.Products.AddRange(products);
        //        context.SaveChanges();
        //    }
        //}
        // Modify the products for updating
        static List<Product> ModifyProductsForUpdate(List<Product> products)
        {
            foreach (var product in products)
            {
                product.Price += 10; // Increase price by 10
                product.Quantity += 1;
                product.Description = "Changed";
                product.ModifiedBy = "System";
                product.IsAvailable = !product.IsAvailable; // Flip availability
            }
            return products;
        }
        // Updates products using standard EF Core Update and SaveChanges.
        static long UpdateWithStandardEFCore()
        {
            using (var context = new EFCoreDbContext())
            {
                // Clear existing data
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
                // Generate initial products and insert them into the database
                var initialProducts = GenerateProducts(2000);
                // Ensure the data is pre-inserted
                InsertWithStandardEFCore(initialProducts);
                // Modify the products to update them
                var updatedProducts = ModifyProductsForUpdate(initialProducts);
                var stopwatch = Stopwatch.StartNew();
                context.Products.UpdateRange(updatedProducts);
                context.SaveChanges();
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Updates products using EFCore.BulkExtensions BulkUpdate.
        static long UpdateWithEFCoreBulkExtensions()
        {
            using (var context = new EFCoreDbContext())
            {
                // Clear existing data
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
                // Generate initial products and insert them into the database
                var initialProducts = GenerateProducts(2000);
                // Ensure the data is pre-inserted
                InsertWithStandardEFCore(initialProducts);
                // Modify the products to update them
                var updatedProducts = ModifyProductsForUpdate(initialProducts);
                var stopwatch = Stopwatch.StartNew();
                // Using EFCore.BulkExtensions for bulk update
                EFCore.BulkExtensions.DbContextBulkExtensions.BulkUpdate(context, updatedProducts);
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
        // Updates products using Z.EntityFramework.Extensions.EFCore BulkUpdate.
        static long UpdateWithZEntityExtensions()
        {
            using (var context = new EFCoreDbContext())
            {
                // Clear existing data
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
                // Generate initial products and insert them into the database
                var initialProducts = GenerateProducts(2000);
                // Ensure the data is pre-inserted
                InsertWithStandardEFCore(initialProducts);
                // Modify the products to update them
                var updatedProducts = ModifyProductsForUpdate(initialProducts);
                var stopwatch = Stopwatch.StartNew();
                // Using Z.EntityFramework.Extensions for bulk update
                DbContextExtensions.BulkUpdate(context, updatedProducts);
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
            // Generates a list of Product instances.
            static List<Product> GenerateProducts(int count)
        {
            var products = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                products.Add(new Product
                {
                    Name = $"Product_{i}",
                    Price = (decimal)(new Random().NextDouble() * 100),
                    Quantity = 100,
                    Description = $"Product_{i} Description",
                    CreatedDate = DateTime.Now,
                    IsAvailable = true,
                    ModifiedBy = "Admin"
                });
            }
            return products;
        }
        // Inserts products using standard EF Core AddRange and SaveChanges.
        static long InsertWithStandardEFCore(List<Product> products)
        {
            using var context = new EFCoreDbContext();
            // Clear existing data to ensure a fair benchmark
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
            var stopwatch = Stopwatch.StartNew();
            context.Products.AddRange(products);
            context.SaveChanges();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        // Inserts products using EFCore.BulkExtensions BulkInsert.
        static long InsertWithEFCoreBulkExtensions(List<Product> products)
        {
            // Insert using EFCore.BulkExtensions
            using var context = new EFCoreDbContext();
            // Clear existing data
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
            var stopwatch = Stopwatch.StartNew();
            EFCore.BulkExtensions.DbContextBulkExtensions.BulkInsert(context, products);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        // Inserts products using Z.EntityFramework.Extensions.EFCore BulkInsert.
        static long InsertWithZEntityExtensions(List<Product> products)
        {
            using var context = new EFCoreDbContext();
            // Clear existing data
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
            var stopwatch = Stopwatch.StartNew();
            DbContextExtensions.BulkInsert(context, products);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}