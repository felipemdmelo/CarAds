using CarAds.Domain.Interfaces.Repositories;
using CarAds.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarAds.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }
    }
}
