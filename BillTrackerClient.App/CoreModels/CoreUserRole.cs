namespace BillTrackerClient.App.CoreModels
{
    public class CoreUserRole
    {
        public int UserRoleId { get; set; }

        public int UserId { get; set; }
        public CoreUser User { get; set; }

        public int RoleId { get; set; }
        public CoreRole Role { get; set; }
    }
}
