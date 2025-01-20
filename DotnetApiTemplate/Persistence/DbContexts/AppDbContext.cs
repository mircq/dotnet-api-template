using System.Collections.Generic;
using System.Reflection.Emit;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }
    public DbSet<TemplateEntity> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API configurations (if needed)
        modelBuilder.Entity<TemplateEntity>()
            .HasKey(c => c.Id);
    }
}