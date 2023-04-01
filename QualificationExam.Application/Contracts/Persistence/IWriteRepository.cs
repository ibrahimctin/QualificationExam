﻿namespace QualificationExam.Application.Contracts.Persistence
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<T> entities);
        Task<int> SaveAsync();
    }
}
