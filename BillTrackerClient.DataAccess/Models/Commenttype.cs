using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Commenttype
    {
        public Commenttype()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentTypeId { get; set; }
        public string CommentType1 { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
