using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using Core.ViewModels;
using Data.Models;

namespace Core.Abstract
{
    public interface IValidationService
    {
        bool ValidateWorkPeriods(ICollection<WorkPeriod> workPeriods);
        bool ValidateNewWorkerModel(NewWorkerModel newWorkerModel);
    }
}
