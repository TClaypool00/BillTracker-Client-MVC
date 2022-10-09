using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwsuggestion
    {
        public int SuggestionId { get; set; }
        public string SuggestHeader { get; set; } = null!;
        public string SuggestBody { get; set; } = null!;
        public DateTime DateSubmitted { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; } = null!;
        public string AuthorLastName { get; set; } = null!;
        public int? SuggestionOption { get; set; }
        public string? WaitingOption { get; set; }
        public string? DenyReason { get; set; }
        public int? ApproveDenyBy { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
