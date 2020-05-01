using ConsoleDemo.Entities;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Extensions;

namespace ConsoleDemo.Enumerable
{
    public class ProductService : IProductService
    {
        private NorthwindContext db;

        public ProductService(NorthwindContext context)
        {
            db = context;
        }


        public IQueryable<Products> FindAll()
        {
            var products = db.Products;
            return products;
        }
    }
}
