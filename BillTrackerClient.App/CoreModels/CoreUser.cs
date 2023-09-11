using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models;
using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreUser
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly User _user;

        public CoreUser()
        {

        }

        public CoreUser(RegisterViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel ?? throw new ArgumentNullException(nameof(registerViewModel));

            FirstName = _registerViewModel.FirstName;
            LastName = _registerViewModel.LastName;
            PhoneNumber = _registerViewModel.PhoneNumber;
            Email = _registerViewModel.Email;
            Password = _registerViewModel.Password;
        }

        public CoreUser(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));

            UserId = _user.UserId;
            FirstName = _user.FirstName;
            LastName= _user.LastName;
            PhoneNumber = _user.PhoneNumber;
            Email = _user.Email;
            Password= _user.Password;


        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public List<CoreUserRole> UserRoles { get; set; }
    }
}
