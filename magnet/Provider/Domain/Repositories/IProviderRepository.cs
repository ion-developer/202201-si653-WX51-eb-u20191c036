namespace magnet.Provider.Domain.Repositories;

public interface IProviderRepository
{
    Task<IEnumerable<Models.Provider>> ListAsync();
    Task AddAsync(Models.Provider provider);
    Task<Models.Provider> FindByIdAsync(int providerId);
}