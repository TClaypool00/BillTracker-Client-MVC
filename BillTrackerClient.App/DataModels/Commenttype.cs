using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Commenttype
    {
        public Commenttype()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentTypeId { get; set; }
        public string CommentType1 { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
