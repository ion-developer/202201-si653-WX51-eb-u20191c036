using magnet.Provider.Domain.Repositories;
using magnet.Provider.Domain.Services;
using magnet.Provider.Domain.Services.Communication;
using magnet.Shared.Domain.Repositories;
namespace magnet.Provider.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.Provider>> ListAsync()
    {
        return await _providerRepository.ListAsync();
    }

    public async Task<ProviderResponse> SaveAsync(Domain.Models.Provider provider)
    {
        try
        {
            await _providerRepository.AddAsync(provider);
            await _unitOfWork.CompleteAsync();

            return new ProviderResponse(provider);
        }
        catch (Exception e)
        {
            return new ProviderResponse($"An error occurred while saving the provider: {e.Message}");
        }
    }

}