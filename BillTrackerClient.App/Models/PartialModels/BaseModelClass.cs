using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PartialModels
{
    public class BaseModelClass
    {
        [Required(ErrorMessage = "Amount due is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount due")]
        public decimal AmountDue { get; set; }
        [Required(ErrorMessage = "Date due is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Amount due")]
        public DateOnly DateDue { get; set; }
        [Required(ErrorMessage = "Please select a company Id")]
        public int CompanyId { get; set; }
        [Display(Name = "Paid?")]
        public bool IsPaid { get; set; }
        [Display(Name = "Late? ")]
        public bool IsLate { get; set; }
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CompanyItem> DropDown { get; set; }
    }
}
