using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Core.Abstract
{
    public interface IDataService
    {
        bool IsWorkerActive(int workerId, DateTime dateTime);
        bool IsWorkerActive(Worker worker, DateTime dateTime);
        Worker GetSingleWorkerByEmail(string email);
        Worker GetWorkerById(int workerId);
        bool IsWorkerSuperior(int superiorId, int subordinateId);
        List<Worker> GetWorkers();
        List<Position> GetPositions();
        void AddWorker(Worker worker);
    }
}
