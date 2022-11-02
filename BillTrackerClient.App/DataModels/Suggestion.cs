using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Suggestion
    {
        public int SuggestionId { get; set; }
        public string SuggestHeader { get; set; }
        public string SuggestBody { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int UserId { get; set; }
        public int? SuggestionOption { get; set; }
        public string DenyReason { get; set; }
        public int? ApproveDenyBy { get; set; }

        public virtual User ApproveDenyByNavigation { get; set; }
        public virtual Watingoption SuggestionOptionNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
