using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class UserViewModel : LoginViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255, ErrorMessage = "First name has max length of 255")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(255, ErrorMessage = "Last name has max length of 255")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
