using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        public int SeniorityFullYears { get; set; }
        public decimal Salary { get; set; }
        public bool IsWork { get; set; }
    }
}
