using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Abstract;
using Core.ViewModels;
using Data.Models;

namespace Core.Services
{
    public class ValidationService : IValidationService
    {


        public bool ValidateWorkPeriods(ICollection<WorkPeriod> workPeriods)
        {
            var listPeriods = workPeriods.ToList();
            for (var i = 0; i < listPeriods.Count; i++)
            {
                //если начало периода больше конца
                if (listPeriods[i].StartDate > (listPeriods[i].FinishDate ?? DateTime.MaxValue))
                    return false;
                
                //если два периода пересекаются
                for (var j = i + 1; j < listPeriods.Count; j++)
                {
                    if (listPeriods[i].StartDate < listPeriods[j].StartDate)
                    {
                        if ((listPeriods[i].FinishDate ?? DateTime.MaxValue) > listPeriods[j].StartDate)
                            return false;
                    }
                    else
                    {
                        if ((listPeriods[j].FinishDate ?? DateTime.MaxValue) > listPeriods[i].StartDate)
                            return false;
                    }
                }
            }
            return true;
        }

        public bool ValidateNewWorkerModel(NewWorkerModel newWorkerModel)
        {
            return true;
        }
    }
}
