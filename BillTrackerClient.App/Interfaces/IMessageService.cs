namespace BillTrackerClient.App.Interfaces
{
    public interface IMessageService
    {
        #region Public methods
        public string IsActiveMessage(string model, bool isActive);
        #endregion
    }
}
