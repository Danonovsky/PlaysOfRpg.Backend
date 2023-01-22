using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories;

internal class InMemoryAttributeRepository : IAttributeRepository
{
    private readonly List<Attribute> _attributes = new();

    public async Task<List<Attribute>> GetAllAsync()
        => _attributes;

    public async Task<Attribute?> GetByIdAsync(Guid id)
        => _attributes.FirstOrDefault(_ => _.Id == id);

    public async Task AddAsync(Attribute model) 
        => _attributes.Add(model);

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

    public async Task DeleteAsync(Guid id) 
        => _attributes.RemoveAll(_ => _.Id == id);
}