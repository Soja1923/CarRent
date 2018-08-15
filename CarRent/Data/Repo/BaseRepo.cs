using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data.Repo
{
    public class BaseRepo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected DbSet<T> Table;
        public async Task AddRange(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await Table.FindAsync(id);
        }
        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
