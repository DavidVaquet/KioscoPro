using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Application.DTOs.Auth
{
    public class RegisterTenantResponseDto
    {
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string Slug { get; set; }
        public Guid Username { get; set; }
        public string UserEmail { get; set; }
        public string SubscriptionPlan { get; set; } = string.Empty;
        public DateTime? TrialEndsAt { get; set; }
        public string Message { get; set; }
    }
}
