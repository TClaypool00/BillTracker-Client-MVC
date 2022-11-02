using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwcompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
