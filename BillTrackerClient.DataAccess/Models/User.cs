using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
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
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
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
