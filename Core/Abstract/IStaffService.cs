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
        List<WorkerViewModel> GetActiveSubordinates(int workerId);
    }
}
