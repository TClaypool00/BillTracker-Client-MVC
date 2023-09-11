using BillTrackerClient.App.DataModels;
using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreRole
    {
        private readonly Role _role;

        public CoreRole()
        {

        }

        public CoreRole(Role role)
        {
            _role = role ?? throw new ArgumentNullException(nameof(role));

            RoleId = _role.RoleId;
            RoleName = _role.RoleName;
        }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public List<CoreUserRole> UserRoles { get; set; }
    }
}
