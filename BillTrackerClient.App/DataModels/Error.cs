using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Error
    {
        public Error()
        {
            Users = new HashSet<User>();
        }

        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public int ErrorLine { get; set; }
        public string StackTrace { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
