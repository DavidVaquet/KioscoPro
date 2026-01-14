using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.Entities
{
    public class PlanPrice
    {
        public Guid Id { get; private set; }
        public Guid PlanId { get; private set; }
        public Plan Plan { get; private set; } = null!;
        public decimal MonthlyPrice { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }

    }
}
