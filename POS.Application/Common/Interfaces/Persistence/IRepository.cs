using POS.Domain.Common.Models;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IRepository<T,TId> where T : Entity<TId> where TId : notnull
{
    Task<T?> GetById(TId Id);
    Task<List<T>> GetList();

    Task Add(T entity);
    Task AddRange(List<T> entities);

    Task Update(T entity);
    Task Delete(List<T> entities);
    Task Delete(List<TId> ids);


    Task<bool> ExistsAsync(TId Id);
}