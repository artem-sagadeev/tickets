using Microsoft.AspNetCore.Mvc;
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
    public async Task<OrganizationDto> GetEvent(Guid organizationId)
    {
        return await _organizationService.GetById(organizationId);
    }
}