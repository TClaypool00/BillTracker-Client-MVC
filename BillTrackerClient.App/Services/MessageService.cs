using BillTrackerClient.App.Interfaces;

namespace BillTrackerClient.App.Services
{
    public class MessageService : IMessageService
    {
        public string IsActiveMessage(string model, bool isActive)
        {
            string message = $"{model} is now ";

            if (isActive)
            {
                message += "active";
            }
            else
            {
                message += "inactive";
            }

            return message;
        }
    }
}
