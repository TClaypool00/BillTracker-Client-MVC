using BillTrackerClient.App.CustomAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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
        public DateTime DateDue { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Company selection is require")]
        public int? CompanyId { get; set; }

        public List<SelectListItem> CompanyDropDown { get; set; }
    }
}
