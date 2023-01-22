using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.DAL;

public class CharacterDbContext : RpgDbContext
{
    private const string SchemaName = "character";
    public CharacterDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attribute> Attributes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);
    }
}