using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Data.Models;

namespace Core.Abstract
{
    public interface IStaffService
    {
        WorkerViewModel GetWorkerByEmail(string email);
        WorkerViewModel GetWorkerById(int workerId);
        List<WorkerViewModel> GetActiveSubordinates(int workerId);
        List<WorkerViewModel> GetWorkers();
        List<PositionViewModel> GetPositions();
        void AddWorker(NewWorkerModel workerModel);
    }
}
