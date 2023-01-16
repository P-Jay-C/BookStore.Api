using Microsoft.AspNetCore.Identity;

namespace BookStore.Api.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
