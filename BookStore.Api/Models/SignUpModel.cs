using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class SignUpModel
    {
        [Required]
        public string  firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Compare("confirmPassword")]
        public string password { get; set; }
        [Required]
        public string confirmPassword { get; set; }
    }
}
