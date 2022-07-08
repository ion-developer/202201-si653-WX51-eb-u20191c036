using magnet.Shared.Domain.Services.Communication;

namespace magnet.Provider.Domain.Services.Communication;

public class ProviderResponse : BaseResponse<Models.Provider>
{
    public ProviderResponse(string message) : base(message)
    {
    }

    public ProviderResponse(Models.Provider resource) : base(resource)
    {
    }   
}