using BillTrackerClient.App.CoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.DataModels
{
    public class User
    {
        private readonly CoreUser _coreUser;

        public User()
        {

        }

        public User(CoreUser coreUser)
        {
            _coreUser = coreUser ?? throw new ArgumentNullException(nameof(coreUser));

            if (_coreUser.UserId > 0)
            {
                UserId = _coreUser.UserId;
            }

            FirstName = _coreUser.FirstName;
            LastName = _coreUser.LastName;
            PhoneNumber = _coreUser.PhoneNumber;
            Email = _coreUser.Email;
            Password = _coreUser.Password;
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
