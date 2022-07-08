using magnet.Provider.Domain.Repositories;
using magnet.Shared.Persistence.Contexts;
using magnet.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace magnet.Provider.Persistence.Repositories;

public class ProviderRepository : BaseRepository , IProviderRepository
{
    public ProviderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Provider>> ListAsync()
    {
        return await _context.Providers
            .ToListAsync();       
    }

    public async Task AddAsync(Domain.Models.Provider provider)
    {
        await _context.Providers.AddAsync(provider);
    }

    public Task<Domain.Models.Provider> FindByIdAsync(int providerId)
    {
        throw new NotImplementedException();
    }
}