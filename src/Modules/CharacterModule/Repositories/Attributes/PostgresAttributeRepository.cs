using CharacterModule.DAL;
using Microsoft.EntityFrameworkCore;
using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories.Attributes;

public class PostgresAttributeRepository : IAttributeRepository
{
    private readonly CharacterDbContext _db;

    public PostgresAttributeRepository(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<List<Attribute>> GetAllAsync()
        => await _db.Attributes.ToListAsync();

    public async Task<Attribute?> GetByIdAsync(Guid id)
        => await _db.Attributes.FirstOrDefaultAsync(_ => _.Id == id);

    public async Task AddAsync(Attribute model)
    {
        await _db.Attributes.AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, Attribute model)
    {
        var attribute = await _db.Attributes.FirstOrDefaultAsync(_ => _.Id == id);
        attribute?.Update(model);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var attribute = await GetByIdAsync(id);
        if (attribute is null)
        {
            return;
        }
        _db.Attributes.Remove(attribute);
        await _db.SaveChangesAsync();
    }
}