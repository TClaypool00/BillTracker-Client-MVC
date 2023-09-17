using BillTrackerClient.App.CoreModels.PartialCoreModels;
using BillTrackerClient.App.Models.PostModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreCompany : PartialCoreCompany
    {
        private readonly PostCompanyViewModel _commentViewModel;
        private int _userId;

        public CoreCompany()
        {
            
        }

        public CoreCompany(PostCompanyViewModel commentViewModel, int userId)
        {
            _commentViewModel = commentViewModel ?? throw new ArgumentNullException(nameof(commentViewModel));

            if (userId <= 0)
            {
                throw new ApplicationException("User Id cannot be less than 0");
            }
            else
            {
                _userId = userId;
            }

            CompanyName = _commentViewModel.CompanyName;
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public CoreUser User { get; set; }
    }
}
