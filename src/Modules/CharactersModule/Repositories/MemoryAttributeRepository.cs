﻿using Attribute = CharactersModule.Entities.Attribute;

namespace CharactersModule.Repositories;

internal class MemoryAttributeRepository : IAttributeRepository
{
    private readonly List<Attribute> _attributes = new();

    public async Task<List<Attribute>> GetAllAsync()
        => _attributes;

    public async Task<Attribute?> GetByIdAsync(Guid id)
        => _attributes.FirstOrDefault(_ => _.Id == id);

    public async Task AddAsync(Attribute model) 
        => _attributes.Add(model);

    public async Task EditAsync(Guid id, Attribute model)
    {
        var attribute = await GetByIdAsync(id);
        if (attribute is null)
        {
            //todo throw exception
            return;
        }

        await DeleteAsync(id);
        await AddAsync(model);
    }

    public async Task DeleteAsync(Guid id) 
        => _attributes.RemoveAll(_ => _.Id == id);
}