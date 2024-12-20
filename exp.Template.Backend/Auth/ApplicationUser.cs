using Microsoft.AspNetCore.Identity;

namespace exp.Template.Backend.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public int TenantId { get; set; }
    }
}
