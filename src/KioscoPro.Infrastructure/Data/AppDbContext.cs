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


            
            base.OnModelCreating(modelBuilder);

        }

    }
}
