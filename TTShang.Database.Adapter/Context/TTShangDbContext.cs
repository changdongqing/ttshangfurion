using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using TTShang.Core.Entities;

namespace TTShang.Database.Adapter.Context;

/// <summary>
/// TTShang database context
/// </summary>
[AppDbContext("DefaultConnection", DbProvider.Npgsql)]
public class TTShangDbContext : AppDbContext<TTShangDbContext>
{
    public TTShangDbContext(DbContextOptions<TTShangDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Students table
    /// </summary>
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Student entity
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(10);
        });
    }
}
