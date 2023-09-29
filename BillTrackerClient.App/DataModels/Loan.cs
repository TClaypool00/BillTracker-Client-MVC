using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BillTrackerClient.App.DataModels
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [Required]
        [MaxLength(255)]
        public string LoanName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double TotalAmountOwed { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [NotMapped]
        public PaymentHistory PaymentHistory { get; set; }

        public List<PaymentHistory> PaymentHistories { get; set; }
    }
}
