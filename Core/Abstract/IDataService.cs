using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Core.Abstract
{
    public interface IDataService
    {
        bool IsWorkerActive(int workerId, DateTime dateTime);
        Worker GetSingleWorkerByEmail(string email);
        Worker GetWorkerById(int workerId);
    }
}
