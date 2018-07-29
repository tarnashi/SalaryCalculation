using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public int? SuperiorId { get; set; }
        [ForeignKey("Id")]
        public virtual Worker Superior { get; set; }
        [ForeignKey("SuperiorId")]
        public virtual ICollection<Worker> Subordinates { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<AccessRole> AccessRoles { get; set; }
        public virtual ICollection<WorkPeriod> WorkPeriods { get; set; }
    }
}
