using System.Collections.Generic;
using System.Reflection.Emit;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts;

public class SQLDbContext : DbContext
{
    public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) {
    }
    public DbSet<TemplateEntity> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TemplateEntity>()
            .HasKey(c => c.Id);
    }
}