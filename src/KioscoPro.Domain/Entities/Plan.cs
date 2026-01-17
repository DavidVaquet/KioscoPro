using KioscoPro.Domain.ValueObjects;
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

        public void AddPrice(Currency currency, BillingPeriod period, decimal amount, DateTime effectiveFrom)
        {
            var current = GetCurrentPrice(effectiveFrom, currency, period);

            if (current != null)
            {
                if (effectiveFrom <= current.EffectiveFrom)
                    throw new InvalidOperationException("El nuevo precio debe empezar después del precio vigente");

                current.CloseTo(effectiveFrom);
            }

            var newPrice = new PlanPrice(Id, currency, period, amount, effectiveFrom, null);
            _prices.Add(newPrice);
        }

        public PlanPrice? GetCurrentPrice(DateTime dateUtc, Currency currency, BillingPeriod period)
        {
            return _prices.FirstOrDefault(p =>
                p.Currency == currency &&
                p.BillingPeriod == period &&
                p.IsActiveAt(dateUtc));
        }

    }
}
