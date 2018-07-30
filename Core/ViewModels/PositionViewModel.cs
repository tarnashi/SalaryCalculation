using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.ViewModels
{
    public class PositionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Название")]
        public string DisplayName { get; set; }
        [DisplayName("Может иметь подчиненных")]
        public bool MayHaveSubordinates { get; set; }

        [DisplayName("Базовая ставка")]
        public decimal BaseSalary { get; set; }
        [DisplayName("Коэф. за год стажа")]
        public decimal SeniorityBonusСoefficient { get; set; }
        [DisplayName("Макс. коэф. за стаж")]
        public decimal MaxTotalSeniorityBonusСoefficient { get; set; }

        [DisplayName("Коэф. за подчиненных")]
        public decimal BonusСoefficientForSubordinates { get; set; }
        [DisplayName("Уровни подчиненных для коэф.")]
        public int NumberSubordinatesLevelsForBonus { get; set; }
    }
}
