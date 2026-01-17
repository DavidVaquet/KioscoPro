using KioscoPro.Domain.ValueObjects;
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
        public Currency Currency { get; private set; } = Currency.ARS;
        public BillingPeriod BillingPeriod { get; private set; } = BillingPeriod.Monthly;
        public decimal Amount { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        protected PlanPrice() { }
        internal PlanPrice(Guid planId, Currency currency, BillingPeriod billingPeriod,
        decimal amount, DateTime effectiveFrom, DateTime? effectiveTo)
        {
            if (amount <= 0) throw new InvalidOperationException("El precio debe ser mayor a 0");

            Id = Guid.NewGuid();
            PlanId = planId;
            Currency = currency;
            BillingPeriod = billingPeriod;
            Amount = amount;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
        }
        internal void CloseTo(DateTime effectiveTo)
        {
            if (effectiveTo <= EffectiveFrom)
            {
                throw new InvalidOperationException("La fecha de fin debe ser mayor a la fecha de inicio");
            }
            EffectiveTo = effectiveTo;
        }
        public bool IsActiveAt(DateTime dateUtc)
        {
            var startOk = dateUtc >= EffectiveFrom;
            var endOk = EffectiveTo == null || dateUtc < EffectiveTo.Value;
            return startOk && endOk;
        }


    }
}
