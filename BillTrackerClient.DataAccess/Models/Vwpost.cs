using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwpost
    {
        public int PostId { get; set; }
        public string PostBody { get; set; } = null!;
        public DateTime DatePosted { get; set; }
        public bool IsEdited { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
