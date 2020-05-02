using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Extensions;

namespace Services.Data
{
    public interface IProductsService : IDataService<Products> { }

    public class ProductsService : IProductsService
    {
        protected NorthwindContext localDbContext { get; set; }

        public ProductsService(NorthwindContext context)
        {
            localDbContext = context;
        }

        protected DbSet<Products> localDbSet
        {
            get
            {
                return this.localDbContext.Set<Products>();
            }
        }

        public IQueryable<Products> FindAll(bool? asNoTracking = true)
        {
            return localDbSet.AsNoTrackingIf(asNoTracking == true);
        }

        public async Task<Products> FindByIdAsync(int id, bool? asNoTracking = true)
        {
            return await FindAll(asNoTracking).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> CreateAsync(Products entity)
        {
            try
            {
                await localDbSet.AddAsync(entity);
                await localDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Products entity)
        {
            try
            {
                localDbSet.Update(entity);
                await localDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIdAsync(id, false);
                localDbSet.Remove(entity);
                await localDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
