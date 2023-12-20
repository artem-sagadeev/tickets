using Organizations.Application.Dto;

namespace Organizations.Application.Interfaces;

public interface IOrganizationService
{
    Task<OrganizationDto?> GetById(Guid organizationId);

    Task<Guid> Create(string login, string name, string passwordHash, string description, string inn, string ogrn);
}