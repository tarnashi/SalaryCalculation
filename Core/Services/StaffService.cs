using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Abstract;
using Core.ViewModels;
using Data.Models;

namespace Core.Services
{
    public class StaffService : IStaffService
    {
        private readonly IDataService _data;
        private readonly IValidationService _validation;
        private readonly IMapper _mapper;

        public StaffService(IDataService dataService, IValidationService validationService, IMapper mapper)
        {
            _data = dataService;
            _validation = validationService;
            _mapper = mapper;
        }

        public WorkerViewModel GetWorkerByEmail(string email)
        {
            Worker worker = _data.GetSingleWorkerByEmail(email);
            var result = GetWorkerViewModelWithSalary(worker);
            return result;
        }

        public List<WorkerViewModel> GetActiveSubordinates(int workerId)
        {
            var result = new List<WorkerViewModel>();
            var worker = _data.GetWorkerById(workerId);
            foreach (var subordinate in worker.Subordinates)
            {
                if (_data.IsWorkerActive(subordinate.Id, DateTime.Now))
                    result.Add(GetWorkerViewModelWithSalary(subordinate));
            }

            return result;
        }

        #region private

        private WorkerViewModel GetWorkerViewModelWithSalary(Worker worker)
        {
            var result = _mapper.Map<WorkerViewModel>(worker);
            decimal salary = GetSalary(worker);
            result.Salary = salary;
            return result;
        }

        private decimal GetSalary(Worker worker)
        {
            int seniorityFullYears = GetSeniorityFullYears(worker, DateTime.Today);
            decimal result = worker.Position.BaseSalary * (1 +
                             Math.Min(worker.Position.SeniorityBonusСoefficient * seniorityFullYears,
                                      worker.Position.MaxTotalSeniorityBonusСoefficient));

            if (worker.Position.BonusСoefficientForSubordinates != 0)
                foreach (var subordinate in worker.Subordinates)
                    result += GetSalary(subordinate) * worker.Position.BonusСoefficientForSubordinates;

            return result;
        }

        private int GetSeniorityFullYears(Worker worker, DateTime calculationDate)
        {
            int seniorityDays = GetSeniorityDays(worker.WorkPeriods, calculationDate.Date);
            int result = 0;
            //если стаж >4 лет, учитываем високосный день
            result += (seniorityDays /= (365 * 4 + 1)) * 4;
            result += seniorityDays / 365;
            return result;
        }

        private int GetSeniorityDays(ICollection<WorkPeriod> workPeriods, DateTime calculationDate)
        {
            int result = 0;
            if(!_validation.ValidateWorkPeriods(workPeriods))
                throw new Exception("");

            //валидные периоды не пересекаются
            var sortedWorkPeriods = workPeriods.OrderBy(wp => wp.StartDate);
            foreach (var period in sortedWorkPeriods)
            {
                if (period.StartDate.Date <= calculationDate.Date)
                {
                    DateTime finishDateTime = (period.FinishDate ?? calculationDate).Date;
                    if (calculationDate.Date < finishDateTime)
                        finishDateTime = calculationDate.Date;
                    result += (finishDateTime - period.StartDate.Date).Days + 1;
                }
                else
                    break;
            }

            return result;
        }
        #endregion
    }
}
