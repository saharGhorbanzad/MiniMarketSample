using Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace Entities.Model
{
    public class UserRole : IdentityUserRole<Guid>, IEntity
    {
        public Role Role { get; set; }
        public  User User { get; set; }
    }
}
