namespace Abstractions.Repositories;

public interface ICrudRepository<T>
{
    public Task<List<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
    public Task AddAsync(T model);
    public Task EditAsync(Guid id, T model);
    public Task DeleteAsync(Guid id);
}