using Microsoft.EntityFrameworkCore;
using PetShop.Common.Domain.Entities;
using PetShop.Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Common.Infra.DataAccess
{
    public class EntityFrameworkRepositoryBase<TKey, T> : IRepository<TKey, T>, IQueryRepository<TKey, T> where T : TEntity<TKey>
    {
        protected DbContext db;

        protected EntityFrameworkRepositoryBase()
        {
        }

        protected EntityFrameworkRepositoryBase(DbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            db.Set<T>().Remove(await ReadAsync(id));
        }

        public async Task<T> ReadAsync(TKey id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ReadAll()
        {
            return db.Set<T>();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
