using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Models;
using Organizations.Application.Dto;
using Organizations.Application.Interfaces;

namespace Organizations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet("{organizationId:guid}")]
    public async Task<ActionResult<OrganizationDto>> GetOrganization(Guid organizationId)
    {
        var organization = await _organizationService.GetById(organizationId);
        
        return organization is null ? NotFound() : Ok(organization);
    }
    
    [HttpPost]
    public async Task<Guid> CreateOrganization(CreateOrganizationModel model)
    {
        return await _organizationService.Create(model.Login, model.Name, model.PasswordHash, model.Description,
            model.Inn, model.Ogrn);
    }
}