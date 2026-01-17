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

        private readonly List<UserRole> _userRoles = new();
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();
        public IReadOnlyCollection<RoleType> Roles => _userRoles.Select(ur => ur.Role).ToList().AsReadOnly();
        public DateTime CreatedAtUtc { get; private set; }
        protected User() {}
        
        public void AddRole(RoleType role)
        {
            if (_userRoles.Any(ur => ur.Role == role))
            {
                throw new InvalidOperationException($"El usuario ya contiene el rol: {role}");
            }
            _userRoles.Add(new UserRole(Id, role));
        }

        public void RemoveRole(RoleType role)
        {
            if (_userRoles.Count == 1)
            {
                throw new InvalidOperationException("El usuario debe tener al menos un rol asignado.");
            }
            
            var roleExisting = _userRoles.FirstOrDefault(ur => ur.Role == role);  
            
            if (roleExisting == null)
            {
                throw new InvalidOperationException($"El usuario no contiene el rol: {role}");
            }

            _userRoles.Remove(roleExisting);
        }

        public void Disable() => IsActive = false;
    }
}
