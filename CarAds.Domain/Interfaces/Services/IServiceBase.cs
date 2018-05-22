using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarAds.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(TEntity obj);
        void Dispose();
    }
}
