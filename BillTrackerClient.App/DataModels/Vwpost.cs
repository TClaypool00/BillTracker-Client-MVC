using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwpost
    {
        public int PostId { get; set; }
        public string PostBody { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
