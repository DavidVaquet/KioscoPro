using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Domain.ValueObjects
{
    public enum RoleType
    {
        Owner = 1,
        Admin = 2,
        Cashier = 3,
        Viewer = 4
    };
}
