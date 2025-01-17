using Persistence.DbContexts;

namespace Persistence.UnitOfWork;

public class UnitOfWork
{
    private readonly AppDbContext _context;

    // Inject DbContext via constructor
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    // Save all changes to the database in a single transaction
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
