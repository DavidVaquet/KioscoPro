using KioscoPro.Domain.Entities;

namespace KioscoPro.Application.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetTenantByIdAsync(Guid id);
        Task<Tenant?> GetTenantBySlugAsync(string slug);
        Task<Tenant> CreateTenantAsync(Tenant tenant);
        Task<bool> TenantEmailExistsAsync(string email);
        Task<bool> TenantSlugExistsAsync(string slug);
    }
}
