using ConsoleDemo.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDemo
{
    partial class Program
    {
        static void CombineTests()
        {
            TestProductService();
        }

        static void TestProductService()
        {
            var allowedIdList = new List<int> { 1, 2, 3 };
            var products = productService.FindAll().Where(x => allowedIdList.Contains(x.ProductId));

            foreach (var id in allowedIdList)
            {
                var product = products.FirstOrDefault(p => p.ProductId == id);
                var prefix = $"{id} - ";
                if (product != null)
                {
                    Console.WriteLine(prefix + product.ProductName);
                }
                else
                {
                    Console.WriteLine(prefix + "Not Found");
                }
            }
        }
    }
}
