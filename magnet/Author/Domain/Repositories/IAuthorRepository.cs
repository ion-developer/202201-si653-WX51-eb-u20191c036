namespace magnet.Author.Domain.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Models.Author>> ListAsync();
    Task AddAsync(Models.Author author);
    Task<Models.Author> FindByIdAsync(int authorId);
    public bool ExistByNames(string first, string last);
    public bool ExistByNick(string nick);
}