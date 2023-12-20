using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizations.Application.Dto;
using Organizations.Application.Interfaces;
using Organizations.Domain.Entities;

namespace Organizations.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public OrganizationService(
        IApplicationContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrganizationDto?> GetById(Guid organizationId)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);

        return organization is null ? null : _mapper.Map<OrganizationDto>(organization);
    }

    public async Task<Guid> Create(string login, string name, string passwordHash, string description, string inn,
        string ogrn)
    {
        var organization = new Organization(login, name, passwordHash, description, inn, ogrn);

        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();

        return organization.Id;
    }
}