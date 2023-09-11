using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email has a max length of 255")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(20, ErrorMessage = "Password has a max length of 20")]
        [MinLength(8, ErrorMessage = "Password has a minimum length of 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
