using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.Entities
{
    public class Plan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = String.Empty;
        public string Code { get; private set; } = String.Empty;
        public bool HasInventoryModule { get; private set; }
        public bool HasReportsModule { get; private set; }
        public int MaxUsers { get; private set; }
        public bool isActive { get; private set; }
        protected Plan() { }

        private readonly List<PlanPrice> _prices = new();
        public IReadOnlyCollection<PlanPrice> Prices => _prices.AsReadOnly();
        public Plan(string name, string code, int maxUser)
        {
            Name = name;
            Code = code;
            MaxUsers = maxUser;
            isActive = true;

        }

        public void AddPrice(decimal monthlyPrice, DateTime effectiveFrom)
        {
            var current = GetCurrentPrice(effectiveFrom);
            if (current != null)
            {
                if (effectiveFrom <= current.EffectiveFrom)
                {
                    throw new InvalidOperationException("El nuevo precio debe empezar después del precio vigente");
                }
                current.CloseTo(effectiveFrom);
            }
        }

        public PlanPrice? GetCurrentPrice(DateTime dateUtc)
        {
            return _prices.FirstOrDefault(p => p.IsActiveAt(dateUtc));
        }

    }
}
