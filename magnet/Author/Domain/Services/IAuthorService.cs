using magnet.Author.Domain.Services.Communication;

namespace magnet.Author.Domain.Services;

public interface IAuthorService
{
    Task<IEnumerable<Models.Author>> ListAsync();
    Task<AuthorResponse> SaveAsync(Models.Author author);
}