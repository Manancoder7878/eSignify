using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
