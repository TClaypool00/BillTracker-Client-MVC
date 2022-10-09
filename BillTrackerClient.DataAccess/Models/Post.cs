using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string PostBody { get; set; } = null!;
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
