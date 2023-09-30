using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BillTrackerClient.App.CoreModels;

namespace BillTrackerClient.App.DataModels
{
    public class Loan
    {
        #region Private fields
        #region Private model fields
        private readonly CoreLoan _coreLoan;
        #endregion
        #endregion

        #region Constructors
        public Loan()
        {

        }

        public Loan(CoreLoan coreLoan)
        {
            _coreLoan = coreLoan ?? throw new ArgumentNullException(nameof(coreLoan));

            if (_coreLoan.LoanId > 0)
            {
                LoanId = _coreLoan.LoanId;
            }

            LoanName = _coreLoan.LoanName;
            TotalAmountOwed = _coreLoan.TotalAmountOwed;
            IsActive = _coreLoan.IsActive;
            UserId = _coreLoan.UserId;
            CompanyId = _coreLoan.CompanyId;
        }
        #endregion

        #region Public properties
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
        #endregion
    }
}
