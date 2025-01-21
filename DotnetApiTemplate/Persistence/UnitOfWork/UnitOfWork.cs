using Persistence.DbContexts;

namespace Persistence.UnitOfWork;

public class UnitOfWork(SQLDbContext context)
{
    private readonly SQLDbContext _context = context;

    // Save all changes to the database in a single transaction
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
