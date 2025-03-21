using System.ComponentModel.DataAnnotations;

namespace MauiAccessorApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "please insert username")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "please insert email")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "please insert password")]
        public string? Password { get; set; }
    }
}
