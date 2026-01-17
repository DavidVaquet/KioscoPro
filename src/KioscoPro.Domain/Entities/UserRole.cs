using KioscoPro.Domain.ValueObjects;

namespace KioscoPro.Domain.Entities
{
    public class UserRole
    {
        public Guid UserId { get; private set; }
        public RoleType Role { get; private set; }

        protected UserRole() { }
        internal UserRole(Guid userId, RoleType role)
        {
            UserId = userId;
            Role = role;
        }
    }
}
