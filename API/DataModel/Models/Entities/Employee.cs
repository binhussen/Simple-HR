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
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gander { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public Boolean Status { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey(nameof(Salary))]
        public Guid SalaryId { get; set; }
        public Salary Salary { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
