using Database;
using System;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            testDB();
        }

        static void testDB()
        {
            using (var db = new NorthwindContext())
            {
                foreach (var prod in db.Products)
                {
                    Console.WriteLine(" - {0}", prod.ProductName);
                }
            }
        }
    }
}
