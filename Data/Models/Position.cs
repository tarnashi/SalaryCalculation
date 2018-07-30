using System.Collections.Generic;

namespace Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool MayHaveSubordinates { get; set; }

        public decimal BaseSalary { get; set; }
        public decimal SeniorityBonusСoefficient { get; set; }
        public decimal MaxTotalSeniorityBonusСoefficient { get; set; }

        public decimal BonusСoefficientForSubordinates { get; set; }
        public int NumberSubordinatesLevelsForBonus { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }

    }
}
