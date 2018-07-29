using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using Data.Models;

namespace Core.Abstract
{
    public interface IValidationService
    {
        bool ValidateWorkPeriods(ICollection<WorkPeriod> workPeriods);
    }
}
