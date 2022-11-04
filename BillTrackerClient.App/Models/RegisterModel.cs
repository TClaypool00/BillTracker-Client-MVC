using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class RegisterModel : UserModel
    {
        [Required(ErrorMessage = "Confirm Password is requried")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do match")]
        [MaxLength(255, ErrorMessage = "Confirm Password has a max length of 255")]
        public string ConfirmPassword { get; set; }
    }
}
