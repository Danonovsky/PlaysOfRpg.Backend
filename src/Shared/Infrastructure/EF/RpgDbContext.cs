using Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class RpgDbContext : DbContext
{

    public RpgDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) 
        => base.OnModelCreating(builder);

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && x.State is EntityState.Added or EntityState.Modified);
        foreach (var entity in entities)
        {
            if(entity.State == EntityState.Added)
                ((BaseEntity)entity.Entity).CreatedAt = DateTime.UtcNow;
            else
                ((BaseEntity)entity.Entity).ModifiedAt = DateTime.UtcNow;
        }
    }
}