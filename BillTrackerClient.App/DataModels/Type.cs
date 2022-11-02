using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Type
    {
        public Type()
        {
            Paymenthistories = new HashSet<Paymenthistory>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Paymenthistory> Paymenthistories { get; set; }
    }
}
