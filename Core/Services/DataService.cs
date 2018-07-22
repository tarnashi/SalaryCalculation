using Core.Abstract;
using Data.DataAccess;

namespace Core.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _ctx;

        public DataService()
        {
            _ctx = new DataContext();
        }
    }
}
