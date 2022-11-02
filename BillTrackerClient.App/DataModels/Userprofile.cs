using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Userprofile
    {
        public int ProfileId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal Budget { get; set; }
        public decimal Savings { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
