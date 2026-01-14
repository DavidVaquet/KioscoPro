using KioscoPro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; } = null!;
        public Guid PlanId { get; private set; }
        public Plan Plan { get; private set; } = null!;
        public SubscriptionStatus Status { get; private set; }
        public DateTime StartDateUtc { get; private set; }
        public DateTime? EndDateUtc { get; private set; }
        public decimal? CurrentMonthlyPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
