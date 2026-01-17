using KioscoPro.Application.Interfaces.Persistence;
using KioscoPro.Application.Interfaces.Repositories;
using KioscoPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace KioscoPro.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;
        private IPlanRepository? _planRepository;
        private IUserRepository? _userRepository;
        private ITenantRepository? _tenantRepository;
        private ISubscriptionRepository? _subscriptionRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context; 
        }

        public IPlanRepository Plans => _planRepository ??= new PlanRepository(_context);
        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public ITenantRepository Tenants => _tenantRepository ??= new TenantRepository(_context);
        public ISubscriptionRepository Subscription => _subscriptionRepository ??= new SubscriptionRepository(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    await _transaction.RollbackAsync();
                }
                finally
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
