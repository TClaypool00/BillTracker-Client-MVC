﻿using BillTrackerClient.App.CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels.BaseModels
{
    public class PostBaseExpenseViewModel
    {
        public virtual double? Price { get; set; }

        [Required(ErrorMessage = "Date due is required")]
        [DateMustPresent(ErrorMessage = "Date cannot be in the previous month")]
        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; } = DateTime.Now;

        public int CompanyId { get; set; }

        [Display(Name = "Enter a company text")]
        [Required(ErrorMessage = "Company text is required")]
        public string CompanyText { get; set; }
    }
}
