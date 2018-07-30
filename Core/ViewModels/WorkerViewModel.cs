using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
        public string Email { get; set; }

        [DisplayName("Стаж")]
        public int SeniorityFullYears { get; set; }
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }
        [DisplayName("Работает")]
        public bool IsWork { get; set; }
    }

    public class NewWorkerModel
    {
        [Required]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Имя")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PositionId { get; set; }
        public int? SuperiorId { get; set; }
    }
}
