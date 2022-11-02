using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwcomment
    {
        public int CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
