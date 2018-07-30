using System;
using System.Linq;
using Core.Abstract;
using Data.DataAccess;
using Data.Models;

namespace Core.Services
{
    public class DataService : IDataService, IDisposable
    {
        private readonly DataContext _ctx;

        public DataService()
        {
            _ctx = new DataContext();
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }

        public bool IsWorkerActive(int workerId, DateTime dateTime)
        {
            Worker worker = _ctx.Workers.Find(workerId);
            return worker.WorkPeriods.Any(p =>
                p.StartDate.Date <= dateTime.Date &&
                !p.FinishDate.HasValue || dateTime <= (p.FinishDate ?? dateTime));
        }

        public Worker GetSingleWorkerByEmail(string email)
        {
            return _ctx.Workers.SingleOrDefault(w => w.Email == email);
        }

        public Worker GetWorkerById(int workerId)
        {
            return _ctx.Workers.Find(workerId);
        }
    }
}
