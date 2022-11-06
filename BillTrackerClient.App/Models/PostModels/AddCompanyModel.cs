using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class AddCompanyModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(255, ErrorMessage = "Company has max length of 255")]
        public string CompanyName { get; set; }
    }
}
