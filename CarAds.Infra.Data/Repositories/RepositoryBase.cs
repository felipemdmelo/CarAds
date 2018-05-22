using CarAds.Domain.Interfaces.Repositories;
using CarAds.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAds.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly CarAdsContext Db;

        public RepositoryBase(CarAdsContext db)
        {
            Db = db;
        }

        public async Task AddAsync(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }
    }
}
