using BillTrackerClient.App.Models.PostModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreBill
    {
        #region Private Fields
        private readonly PostBillViewModel _postBillViewModel;
        #endregion

        #region Constructors
        public CoreBill()
        {
            
        }

        public CoreBill(PostBillViewModel postBillViewModel)
        {
            _postBillViewModel = postBillViewModel ?? throw new ArgumentNullException(nameof(postBillViewModel));

        }
        #endregion

        #region Public properties
        public int BillId { get; set; }

        public string BillName { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public CoreUser User { get; set; }
        #endregion
    }
}
