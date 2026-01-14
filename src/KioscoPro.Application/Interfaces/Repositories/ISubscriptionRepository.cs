
using KioscoPro.Domain.Entities;

namespace KioscoPro.Application.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription?> GetSubscriptionByTenantIdAsync(Guid tenantId);
        Task UpdateSubscriptionAsync(Subscription subscription);
    }
}
