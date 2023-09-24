﻿using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreBill : CoreExpense
    {
        //TODO: Pie Chart for 
        //TODO: Get back per month per year
        //TODO: Promotion based on bills
        //TODO: Chatbot helper maybe in Python?
        //Search for news articles

        #region Private fields

        #region Private model fields
        private readonly PostBillViewModel _postBillViewModel;
        private readonly Bill _bill;
        private readonly UpdateBillViewModel _updateBillViewModel;
        #endregion
        #endregion

        #region Constructors
        public CoreBill()
        {
            
        }

        public CoreBill(PostBillViewModel postBillViewModel, int userId) : base(postBillViewModel, userId)
        {
            _postBillViewModel = postBillViewModel ?? throw new ArgumentNullException(nameof(postBillViewModel));

            BillName = _postBillViewModel.BillName;
        }

        public CoreBill(UpdateBillViewModel updateBillViewModel, int userId) : base(updateBillViewModel, userId)
        {
            _updateBillViewModel = updateBillViewModel ?? throw new ArgumentNullException(nameof(updateBillViewModel));

            BillId = _updateBillViewModel.BillId;
            BillName = _updateBillViewModel.BillName;
        }

        public CoreBill(Bill bill)
        {
            _bill = bill ?? throw new ArgumentNullException(nameof(bill));

            BillId = _bill.BillId;
            BillName = _bill.BillName;
            DateCreated = _bill.DateCreated;
            IsActive = _bill.IsActive;

            if (_bill.PaymentHistory is not null)
            {
                Price = _bill.PaymentHistory.Price;
                DateDue = _bill.PaymentHistory.DateDue;
                DatePaid = _bill.PaymentHistory.DatePaid;
            }

            if (_bill.Company is not null)
            {
                Company = new CoreCompany
                {
                    CompanyName = _bill.Company.CompanyName
                };
            }
        }
        #endregion

        #region Public properties
        public int BillId { get; set; }

        public string BillName { get; set; }
        #endregion
    }
}
