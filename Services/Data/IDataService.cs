using Database;
using Database.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public interface IDataService<IEntity>
    {
        IQueryable<IEntity> FindAll(bool? asNoTracking = true);

        Task<IEntity> FindByIdAsync(int id, bool? asNoTracking = true);

        Task<bool> CreateAsync(IEntity entity);

        Task<bool> UpdateAsync(IEntity entity);

        Task<bool> DeleteAsync(int id);
    }
}