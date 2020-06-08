using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GatewaysManager.Models.Database;

namespace GatewaysManager.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task<T> AddAsync<T>(T entity) where T : Entity;
        Task<T> DeleteAsync<T>(T entity) where T : Entity;
        Task<T> GetByIdAsync<T>(Guid id) where T : Entity;
        Task<List<T>> ListAsync<T>() where T : Entity;
        Task<T> Update<T>(T entity) where T : Entity;
    }
}