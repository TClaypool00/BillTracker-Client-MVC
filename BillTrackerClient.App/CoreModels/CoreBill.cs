using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.Models.PostModels;
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

        private readonly PostBillViewModel _postBillViewModel;

        #region Constructors
        public CoreBill()
        {
            
        }

        public CoreBill(PostBillViewModel postBillViewModel, int userId) : base(postBillViewModel, userId)
        {
            _postBillViewModel = postBillViewModel ?? throw new ArgumentNullException(nameof(postBillViewModel));

            BillName = _postBillViewModel.BillName;
        }
        #endregion

        #region Public properties
        public int BillId { get; set; }

        public string BillName { get; set; }
        #endregion
    }
}
