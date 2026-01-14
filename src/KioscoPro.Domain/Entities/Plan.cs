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
    }
}
