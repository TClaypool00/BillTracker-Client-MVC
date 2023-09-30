using BillTrackerClient.App.CoreModels.AbstractModels;
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

        #region Constructors
        public CoreBill()
        {
            
        }

        public CoreBill(PostBillViewModel postBillViewModel, int userId) : base(postBillViewModel, userId)
        {
            BillName = _postBillViewModel.BillName;
        }

        public CoreBill(UpdateBillViewModel updateBillViewModel, int userId) : base(updateBillViewModel, userId)
        {
            BillId = _updateBillViewModel.BillId;
            BillName = _updateBillViewModel.BillName;
        }

        public CoreBill(Bill bill) :base(bill)
        {
            BillId = _bill.BillId;
            BillName = _bill.BillName;
        }
        #endregion

        #region Public properties
        public int BillId { get; set; }

        public string BillName { get; set; }
        #endregion
    }
}
