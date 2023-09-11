using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.DataModels
{
    public class UserRole
    {
        public UserRole()
        {

        }

        public UserRole(int userId)
        {
            UserId = userId;
            RoleId = 1;
        }

        [Key]
        public int UserRoleId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
