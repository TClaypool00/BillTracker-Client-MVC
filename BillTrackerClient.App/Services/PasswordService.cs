using BillTrackerClient.App.Interfaces;
using System.Text.RegularExpressions;

namespace BillTrackerClient.App.Services
{
    public class PasswordService : IPasswordservice
    {
        public string PasswordDoesNotMeetRequirements => "Password does not meet our requirements.";

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool PasswordMeetsRequirements(string password)
        {
            return Regex.IsMatch(password, @"^(.{8,20}|[^0-9]*|[^A-Z])$");
        }

        public bool VerifyPassword(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
