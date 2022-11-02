using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Watingoption
    {
        public Watingoption()
        {
            Suggestions = new HashSet<Suggestion>();
        }

        public int OptionId { get; set; }
        public string WaitingOption { get; set; }

        public virtual ICollection<Suggestion> Suggestions { get; set; }
    }
}
