using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class AddBillModel
    {
        [Required(ErrorMessage = "Bill name is required")]
        [MaxLength(255, ErrorMessage = "Bill name  has max length of 255")]
        [Display(Name = "Bill name")]
        public string BillName { get; set; }
        [Required(ErrorMessage = "Amount due is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount due")]
        public decimal AmountDue { get; set; }
        [Required(ErrorMessage = "Date due is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Amount due")]
        public DateTime DateDue { get; set; }
        [Required(ErrorMessage = "Please select a company Id")]
        public int CompanyId { get; set; }
        public List<CompanyItem> DropDown { get; set; }
    }
}
