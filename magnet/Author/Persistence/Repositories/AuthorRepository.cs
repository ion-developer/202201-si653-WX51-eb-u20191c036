using magnet.Shared.Persistence.Contexts;
using magnet.Shared.Persistence.Repositories;
using magnet.Author.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace magnet.Author.Persistence.Repositories;

public class AuthorRepository : BaseRepository, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Author>> ListAsync()
    {
        return await _context.Authors
            .ToListAsync();
    }

    public async Task AddAsync(Domain.Models.Author author)
    {
        await _context.Authors.AddAsync(author);
    }

    public bool ExistByNames(string first, string last)
    {
        return _context.Authors.Any(p => p.FirstName == first) && _context.Authors.Any(p => p.LastName == last);
    }

    public bool ExistByNick(string nick)
    {
        return _context.Authors.Any(p => p.Nickname == nick);
    }

    public async Task<Domain.Models.Author> FindByIdAsync(int authorId)
    {
        return await _context.Authors
            .FirstOrDefaultAsync(p => p.Id == authorId);
    }


    public void Update(Domain.Models.Author author)
    {
        _context.Authors.Update(author);
    }

    public void Remove(Domain.Models.Author author)
    {
        _context.Authors.Remove(author);
    }
}