using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class RegisterModel : UserModel
    {
        [Required(ErrorMessage = "Confirm Password is requried")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do match")]
        public string ConfirmPassword { get; set; }
    }
}
