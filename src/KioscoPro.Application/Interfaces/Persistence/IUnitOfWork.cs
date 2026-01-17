using KioscoPro.Application.Interfaces.Repositories;

namespace KioscoPro.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IPlanRepository Plans { get; }
        ITenantRepository Tenants { get; }
        ISubscriptionRepository Subscription { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
