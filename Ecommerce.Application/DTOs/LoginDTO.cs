using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs
{
    public record LoginDTO(
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        string email,

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        string password);
}