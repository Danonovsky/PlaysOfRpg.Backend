using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories;

public class PostgresAttributeRepository : IAttributeRepository
{
    public Task<List<Attribute>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Attribute?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Attribute model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, Attribute model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}