using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class UserModel : LoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "First name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Number must be valid phone number")]
        public string PhoneNum { get; set; }
        [Display(Name = "Is admin?")]
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
