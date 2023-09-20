using BillTrackerClient.App.CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostBillViewModel
    {
        [Required(ErrorMessage = "Bill name is required")]
        [MaxLength(255, ErrorMessage = "Bill name is has max length of 255")]
        [Display(Name = "Bill name")]
        public string BillName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(.01, double.MaxValue, ErrorMessage = "Price has range between $0.01 to $1,790,000")]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Date due is required")]
        [DateMustPresent(ErrorMessage = "Date cannot be in the previous month")]
        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; }

        public int CompanyId { get; set; }

        [Display(Name = "Enter a company text")]
        [Required(ErrorMessage = "Company text is required")]
        public string CompanyText { get; set; }
    }
}
