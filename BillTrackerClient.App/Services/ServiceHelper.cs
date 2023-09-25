using BillTrackerClient.App.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class ServiceHelper
    {
        protected readonly BillTrackerContext _context;
        protected readonly string _modelString;

        protected int _index;

        public ServiceHelper(BillTrackerContext context)
        {
            _context = context;
        }

        public ServiceHelper(BillTrackerContext context, string modelName)
        {
            _context = context;
            _modelString = modelName;
        }

        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected void ConfigureIndex(int? index)
        {
            if (index is null  || index == 0)
            {
                _index = 0;
            }
            else
            {
                _index = index.Value * 10;
            }
        }

        protected void Detach(object model)
        {
            if (model is not null)
            {
                _context.Entry(model).State = EntityState.Detached;
            }
        }

        protected string CouldNotAddMessage(string model)
        {
            return $"{model} could not be added";
        }

        public string ModelAlreadyExistsMessage(string model, string name)
        {
            return $"A {model} with the name {name} aready exists.";
        }
    }
}
