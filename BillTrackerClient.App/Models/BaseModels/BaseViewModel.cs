using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.BaseModels
{
    public abstract class BaseViewModel
    {
        #region Public Property
        [Display(Name = "Date Created")]
        public string DateCreated { get; set; }

        [Display(Name = "Price")]
        public string PriceString { get; set; }

        public string Company { get; set; }

        [Display(Name = "Date paid")]
        public string DatePaid { get; set; }

        [Display(Name = "Date Due")]
        public string DateDueString { get; set; }
        #endregion
    }
}
