using Common.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Organizations.Application.Dto;
using Organizations.Application.Interfaces;
using Organizations.Domain.Entities;

namespace Organizations.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IApplicationContext _context;

    public OrganizationService(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<OrganizationDto> GetById(Guid organizationId)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId)
                           ?? throw new EntityNotFoundException();

        return new OrganizationDto
        {
            Id = organization.Id,
            Name = organization.Name
        };
    }
}