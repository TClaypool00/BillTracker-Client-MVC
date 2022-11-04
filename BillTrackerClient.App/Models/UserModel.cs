using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class UserModel : LoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        [MaxLength(255, ErrorMessage = "First name has max length of 255")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        [MaxLength(255, ErrorMessage = "Last name has max length of 255")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Must be valid phone number")]
        public string PhoneNum { get; set; }
        [Display(Name = "Is admin?")]
        public bool IsAdmin { get; set; }
    }
}
