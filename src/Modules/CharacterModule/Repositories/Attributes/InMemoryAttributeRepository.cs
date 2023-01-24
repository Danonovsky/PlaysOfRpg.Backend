using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories.Attributes;

internal class InMemoryAttributeRepository : IAttributeRepository
{
    private readonly List<Attribute> _attributes = new();

    public Task<List<Attribute>> GetAllAsync()
        => Task.FromResult(_attributes);

    public Task<Attribute?> GetByIdAsync(Guid id)
        => Task.FromResult(_attributes.FirstOrDefault(_ => _.Id == id));

    public Task AddAsync(Attribute model)
    {
        _attributes.Add(model);
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Guid id, Attribute model)
    {
        var attribute = await GetByIdAsync(id);
        if (attribute is null)
        {
            //todo throw exception
            return;
        }

        attribute.Name = model.Name;
        attribute.Value = model.Value;
    }

    public Task DeleteAsync(Guid id) 
        => Task.FromResult(_attributes.RemoveAll(_ => _.Id == id));
}