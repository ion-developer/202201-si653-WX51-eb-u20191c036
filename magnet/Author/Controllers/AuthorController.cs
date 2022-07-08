using AutoMapper;
using magnet.Shared.Extensions;
using magnet.Author.Domain.Services;
using magnet.Author.Resources;
using Microsoft.AspNetCore.Mvc;

namespace magnet.Author.Controllers;
[Produces("application/json")]
[ApiController]
[Route("/api/v1/authors")]
    
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorResource>> GetAllAsync()
    {
        var authors = await _authorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Author>, IEnumerable<AuthorResource>>(authors);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var author = _mapper.Map<SaveAuthorResource, Domain.Models.Author>(resource);

        var result = await _authorService.SaveAsync(author);

        if (!result.Success)
            return BadRequest(result.Message);

        var authorResource = _mapper.Map<Domain.Models.Author, AuthorResource>(result.Resource);

        return Ok(authorResource);
    }
}