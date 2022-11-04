using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be a valid email address")]
        [Display(Name = "Email Address")]
        [MaxLength(255, ErrorMessage = "Email address has max length of 255")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(255, ErrorMessage = "Password has max length of 255")]
        public string Password { get; set; }
    }
}
