using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Type
    {
        public Type()
        {
            Paymenthistories = new HashSet<Paymenthistory>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Paymenthistory> Paymenthistories { get; set; }
    }
}
