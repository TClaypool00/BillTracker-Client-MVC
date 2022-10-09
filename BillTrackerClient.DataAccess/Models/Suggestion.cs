using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Suggestion
    {
        public int SuggestionId { get; set; }
        public string SuggestHeader { get; set; } = null!;
        public string SuggestBody { get; set; } = null!;
        public DateTime DateSubmitted { get; set; }
        public int UserId { get; set; }
        public int? SuggestionOption { get; set; }
        public string? DenyReason { get; set; }
        public int? ApproveDenyBy { get; set; }

        public virtual User? ApproveDenyByNavigation { get; set; }
        public virtual Watingoption? SuggestionOptionNavigation { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
