using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Comment
    {
        public Comment()
        {
            Replies = new HashSet<Reply>();
        }

        public int CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public int ParentId { get; set; }

        public virtual Commenttype Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
