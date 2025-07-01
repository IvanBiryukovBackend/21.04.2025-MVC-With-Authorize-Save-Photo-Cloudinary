using Microsoft.AspNetCore.Identity;

namespace ASPNETCoreMVCWithAuth.Domains
{
    public class User : IdentityUser
    {
        public string? ProfileImage { get; set; }
    }
}
