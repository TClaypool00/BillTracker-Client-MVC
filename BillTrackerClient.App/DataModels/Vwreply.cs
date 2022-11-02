using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwreply
    {
        public int ReplyId { get; set; }
        public string ReplyBody { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
