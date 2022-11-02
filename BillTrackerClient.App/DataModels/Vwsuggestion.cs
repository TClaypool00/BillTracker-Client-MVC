using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwsuggestion
    {
        public int SuggestionId { get; set; }
        public string SuggestHeader { get; set; }
        public string SuggestBody { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int? SuggestionOption { get; set; }
        public string WaitingOption { get; set; }
        public string DenyReason { get; set; }
        public int? ApproveDenyBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
