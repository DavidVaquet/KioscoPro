using KioscoPro.Application.Interfaces.Repositories;
using KioscoPro.Domain.Entities;
using KioscoPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KioscoPro.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;
        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> CreateTenantAsync(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }
        public async Task<Tenant?> GetTenantByIdAsync(Guid id)
        {
            return await _context.Tenants
                                 .Include(t => t.Subscription)
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Tenant?> GetTenantBySlugAsync(string slug)
        {
            return await _context.Tenants
                                 .Include(t => t.Subscription)
                                 .FirstOrDefaultAsync(t => t.CompanySlug == slug);
        }
        public async Task<bool> TenantEmailExistsAsync(string email)
        {
            return await _context.Tenants.AnyAsync(t => t.CompanyEmail == email);
        }
        public async Task<bool> TenantSlugExistsAsync(string slug)
        {
            return await _context.Tenants.AnyAsync(t => t.CompanySlug == slug);
        }
    }
}
