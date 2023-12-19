using Organizations.Application.Dto;

namespace Organizations.Application.Interfaces;

public interface IOrganizationService
{
    Task<OrganizationDto?> GetById(Guid organizationId);
}