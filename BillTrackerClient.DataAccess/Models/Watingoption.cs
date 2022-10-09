using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Watingoption
    {
        public Watingoption()
        {
            Suggestions = new HashSet<Suggestion>();
        }

        public int OptionId { get; set; }
        public string WaitingOption { get; set; } = null!;

        public virtual ICollection<Suggestion> Suggestions { get; set; }
    }
}
