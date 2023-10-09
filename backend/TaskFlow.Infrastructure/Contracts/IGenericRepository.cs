namespace TaskFlow.Infrastructure.Contracts;

public interface IGenericRepository<T> where T: class
{
    public Task<bool> AddAsync(T entity);
    public Task<bool> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(T entity);
}