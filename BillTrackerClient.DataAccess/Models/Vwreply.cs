using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwreply
    {
        public int ReplyId { get; set; }
        public string ReplyBody { get; set; } = null!;
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
