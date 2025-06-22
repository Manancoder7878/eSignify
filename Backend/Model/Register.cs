using Backend.CustomValidators;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Register
    {
        public Guid RegisterId { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public required string Name { get; set; }
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public required string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        [StringLength(100,MinimumLength =8,ErrorMessage = "Password must be at least 8 characters long.")]
        public required string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password is required.")]
        [CheckPassword("Password",ErrorMessage = "Confirm Password does not match Password.")]
        public required string ConfirmPassword { get; set; }

    }
}
