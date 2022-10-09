using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Error
    {
        public Error()
        {
            Users = new HashSet<User>();
        }

        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; } = null!;
        public int ErrorCode { get; set; }
        public int ErrorLine { get; set; }
        public string StackTrace { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
