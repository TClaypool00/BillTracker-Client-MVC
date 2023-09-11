using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class RegisterViewModel : UserViewModel
    {
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string ComparePassword { get; set; }
    }
}
