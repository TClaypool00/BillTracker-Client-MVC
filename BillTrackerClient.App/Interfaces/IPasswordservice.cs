namespace BillTrackerClient.App.Interfaces
{
    public interface IPasswordservice
    {
        #region public methods
        public string HashPassword(string password);

        public bool VerifyPassword(string hash, string password);

        public bool PasswordMeetsRequirements(string password);
        #endregion

        #region public properties
        public string PasswordDoesNotMeetRequirements { get; }
        #endregion
    }
}
