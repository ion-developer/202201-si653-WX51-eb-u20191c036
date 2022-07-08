using AutoMapper;
using magnet.Author.Resources;
using magnet.Provider.Resources;
namespace magnet.Shared.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAuthorResource, Author.Domain.Models.Author>();
        CreateMap<SaveProviderResource, Provider.Domain.Models.Provider>();
    }
}