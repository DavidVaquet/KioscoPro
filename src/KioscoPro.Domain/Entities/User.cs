using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioscoPro.Domain.ValueObjects;

namespace KioscoPro.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Username { get; private set; }
        public string UserEmail { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }
        public string PasswordHash { get; private set; }

        private readonly List<RoleType> _roles = new();
        public IReadOnlyCollection<RoleType> Roles => _roles.AsReadOnly();
        public DateTime CreatedAtUtc { get; private set; }
        protected User() {}
        public void AddRole(RoleType role)
        {
            if (_roles.Any(r => r == role))
            {
                throw new InvalidOperationException($"El usuario ya tiene el rol: {role}");
            }

            _roles.Add(role);
        }

        public void RemoveRole(RoleType role)
        {   

            if (_roles.Count == 1)
            {
                throw new InvalidOperationException("El usuario debe tener al menos un rol");
            }


            if (!_roles.Any(r => r == role))
            {
                throw new InvalidOperationException($"El usuario no contiene el rol: {role}");
            }

            _roles.Remove(role);
        }

        public void Disable() => IsActive = false;
    }
}
