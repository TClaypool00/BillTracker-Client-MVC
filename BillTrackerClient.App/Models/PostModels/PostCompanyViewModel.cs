using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostCompanyViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(255, ErrorMessage = "Company name has a max length of 255")]
        public string CompanyName { get; set; }
    }
}
