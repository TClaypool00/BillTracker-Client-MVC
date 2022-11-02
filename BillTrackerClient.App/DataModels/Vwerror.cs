using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwerror
    {
        public int? ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public int? ErrorCode { get; set; }
        public int? ErrorLine { get; set; }
        public string StackTrace { get; set; }
        public long UsersCount { get; set; }
    }
}
