using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.DataModels
{
    public class Role
    {
        public Role()
        {

        }

        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(255)]
        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
