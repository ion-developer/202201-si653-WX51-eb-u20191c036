using AutoMapper;
using magnet.Author.Resources;
using magnet.Provider.Resources;
namespace magnet.Shared.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Author.Domain.Models.Author, AuthorResource>();
        CreateMap<Provider.Domain.Models.Provider, ProviderResource>();
    }
}
