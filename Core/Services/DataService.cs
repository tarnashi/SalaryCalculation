using System;
using System.Linq;
using Core.Abstract;
using Data.DataAccess;
using System.Collections.Generic;

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
    }
}
