using BillTrackerClient.App.CoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.DataModels
{
    public class Company
    {
        private readonly CoreCompany _company;

        public Company()
        {

        }

        public Company(CoreCompany company)
        {
            _company = company ?? throw new ArgumentNullException(nameof(company));

            if (_company.CompanyId > 0)
            {
                CompanyId = _company.CompanyId;
            }

            CompanyName = _company.CompanyName;
            UserId = _company.UserId;
        }

        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Bill> Bills { get; set; }
    }
}
