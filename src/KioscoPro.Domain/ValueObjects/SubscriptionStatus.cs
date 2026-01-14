using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.ValueObjects
{
    public enum SubscriptionStatus
    {
        Active = 1,
        Trial = 2,
        Expired = 3,
        Canceled = 4,
        Suspended = 5
    }
}
