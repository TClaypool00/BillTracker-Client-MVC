using BillTrackerClient.App.DataModels;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class ServiceHelper
    {
        protected readonly BillTrackerContext _context;

        public ServiceHelper(BillTrackerContext context)
        {
            _context = context;
        }

        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
