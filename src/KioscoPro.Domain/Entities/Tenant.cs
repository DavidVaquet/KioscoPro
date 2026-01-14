using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; private set; }
        public string CompanyName { get; private set; } = string.Empty;
        public string CompanySlug { get; private set; } = String.Empty;
        public string? CompanyEmail { get; private set; } = String.Empty;
        public string? CompanyPhone { get; private set; } = String.Empty;
        public string CompanyAddress { get; private set; } = String.Empty;
        public bool IsActive { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime DesactivedAt { get; private set; }
        public Subscription? Subscription { get; private set; } = null!;

        protected Tenant() {}
        public void Disable() => IsActive = false;

    }
}
