using KioscoPro.Application.Interfaces.Repositories;
using KioscoPro.Domain.Entities;
using KioscoPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KioscoPro.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;
        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            return subscription;
        }
        public async Task<Subscription?> GetSubscriptionByTenantIdAsync(Guid tenantId)
        {
            return await _context.Subscriptions
                                 .Include(s => s.Tenant)
                                 .FirstOrDefaultAsync(s => s.TenantId == tenantId);
        }
        public async Task<int> UpdateSubscriptionAsync(Subscription subscription)
        {
            return await _context.Subscriptions
                .Where(s => s.Id == subscription.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.Status, subscription.Status)
                    .SetProperty(s => s.EndDateUtc, subscription.EndDateUtc)
                    .SetProperty(s => s.CurrentMonthlyPrice, subscription.CurrentMonthlyPrice)
                    .SetProperty(s => s.UpdatedAt, DateTime.UtcNow)
                );
        }
    }
}
