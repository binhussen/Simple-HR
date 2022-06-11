using DataModel.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Employee : BaseEntity
    {
        [Column("EmployeeId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gander { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public Boolean Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int SalaryId { get; set; }
        [ForeignKey("SalaryId")]
        public virtual Salary Salary { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
