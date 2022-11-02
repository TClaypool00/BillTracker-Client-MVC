using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Companies = new HashSet<Company>();
            Posts = new HashSet<Post>();
            Replies = new HashSet<Reply>();
            SuggestionApproveDenyByNavigations = new HashSet<Suggestion>();
            SuggestionUsers = new HashSet<Suggestion>();
            Userprofiles = new HashSet<Userprofile>();
            Errors = new HashSet<Error>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Suggestion> SuggestionApproveDenyByNavigations { get; set; }
        public virtual ICollection<Suggestion> SuggestionUsers { get; set; }
        public virtual ICollection<Userprofile> Userprofiles { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
    }
}
