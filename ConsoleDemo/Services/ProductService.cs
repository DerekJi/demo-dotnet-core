using ConsoleDemo.Entities;
using Database;
using Database.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleDemo.Enumerable
{
    public class ProductService : IProductService
    {
        private NorthwindContext db;

        public ProductService(NorthwindContext context)
        {
            db = context;
        }

    }
}
