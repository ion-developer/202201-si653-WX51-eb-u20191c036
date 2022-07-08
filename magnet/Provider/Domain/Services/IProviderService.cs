using magnet.Provider.Domain.Services.Communication;

namespace magnet.Provider.Domain.Services;

public interface IProviderService
{
    Task<IEnumerable<Models.Provider>> ListAsync();
    Task<ProviderResponse> SaveAsync(Models.Provider provider);
}