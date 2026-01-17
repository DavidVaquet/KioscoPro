using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using KioscoPro.Domain.Entities;

namespace KioscoPro.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<PlanPrice> PlanPrices => Set<PlanPrice>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TENANT
            modelBuilder.Entity<Tenant>()
                        .ToTable("tenants")
                        .HasKey(t => t.Id);

            //USERS
            modelBuilder.Entity<User>()
                        .ToTable("users")
                        .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                        .HasOne<Tenant>()
                        .WithMany()
                        .HasForeignKey(u => u.TenantId)
                        .OnDelete(DeleteBehavior.Cascade);

            //USERS ROLE
            modelBuilder.Entity<UserRole>()
                        .ToTable("user_roles")
                        .HasKey(ur => new { ur.UserId, ur.Role });

            modelBuilder.Entity<UserRole>()
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey(ur => ur.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // SUSCRIPCIONES
            modelBuilder.Entity<Subscription>()
                        .ToTable("subscriptions")
                        .HasKey(s => s.Id);

            modelBuilder.Entity<Subscription>()
                        .HasOne(s => s.Plan)
                        .WithMany()
                        .HasForeignKey(s => s.PlanId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                        .HasOne(s => s.Tenant)
                        .WithMany(t => t.Subscriptions)
                        .HasForeignKey(s => s.TenantId);

            // PLANES
            modelBuilder.Entity<Plan>()
                        .ToTable("plans")
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Plan>()
                        .HasMany(p => p.Prices)
                        .WithOne(pp => pp.Plan)
                        .HasForeignKey(pp => pp.PlanId)
                        .OnDelete(DeleteBehavior.Cascade);

            // PLAN PRICES
            modelBuilder.Entity<PlanPrice>()
                        .ToTable("plan_prices")
                        .HasKey(pp => pp.Id);

            modelBuilder.Entity<PlanPrice>()
                        .HasIndex(pp => new { pp.PlanId, pp.Currency, pp.BillingPeriod })
                        .IsUnique()
                        .HasFilter("\"effective_to\" IS NULL");

            base.OnModelCreating(modelBuilder);

        }

    }
}
