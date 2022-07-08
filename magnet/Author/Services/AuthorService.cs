using AutoMapper;
using magnet.Shared.Domain.Repositories;
using magnet.Author.Domain.Repositories;
using magnet.Author.Domain.Services;
using magnet.Author.Domain.Services.Communication;

namespace magnet.Author.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _AuthorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _AuthorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Domain.Models.Author>> ListAsync()
    {
        return await _AuthorRepository.ListAsync();
    }

    public async Task<AuthorResponse> SaveAsync(Domain.Models.Author author)
    {
        var existingWithNames = _AuthorRepository.ExistByNames(author.FirstName, author.LastName);

        if (existingWithNames)
            return new AuthorResponse("Names combination already exist");

        var existingWithNick = _AuthorRepository.ExistByNick(author.Nickname);

        if (existingWithNick)
            return new AuthorResponse("Nickname already exist");

        try
        {
            await _AuthorRepository.AddAsync(author);
            await _unitOfWork.CompleteAsync();

            return new AuthorResponse(author);
        }
        catch (Exception e)
        {
            return new AuthorResponse($"An error occurred while saving the author: {e.Message}");
        }
    }
}