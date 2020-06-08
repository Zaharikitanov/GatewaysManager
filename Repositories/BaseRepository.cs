using GatewaysManager.DatabaseContext;
using GatewaysManager.Models.Database;
using GatewaysManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GatewaysManager.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public GatewaysManagerContext _dbContext;

        public BaseRepository(GatewaysManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<List<T>> ListAsync<T>() where T : Entity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> DeleteAsync<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
