using AutoMapper;
using magnet.Provider.Domain.Services;
using magnet.Provider.Resources;
using magnet.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace magnet.Provider.Controllers;
[Produces("application/json")]
[ApiController]
[Route("/api/v1/providers")]
public class ProvidersController: ControllerBase
{
    private readonly IProviderService _providerService;
    private readonly IMapper _mapper;
    

    public ProvidersController(IProviderService providerService, IMapper mapper)
    {
        _providerService = providerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProviderResource>> GetAllAsync()
    {
        var providers = await _providerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Provider>, IEnumerable<ProviderResource>>(providers);

        return resources;
    }
        
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var provider = _mapper.Map<SaveProviderResource, Domain.Models.Provider>(resource);

        var result = await _providerService.SaveAsync(provider);

        if (!result.Success)
            return BadRequest(result.Message);

        var providerResource = _mapper.Map<Domain.Models.Provider, ProviderResource>(result.Resource);

        return Ok(providerResource);
    }
}