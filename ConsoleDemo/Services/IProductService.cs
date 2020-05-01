using ConsoleDemo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.Enumerable
{
    public interface IProductService
    {
        IQueryable<Products> FindAll();
    }
}
