using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwuser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int ProfileId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal Budget { get; set; }
        public decimal Savings { get; set; }
    }
}
