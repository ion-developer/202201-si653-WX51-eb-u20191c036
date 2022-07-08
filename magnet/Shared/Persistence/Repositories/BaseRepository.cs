using magnet.Shared.Persistence.Contexts;

namespace magnet.Shared.Persistence.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}