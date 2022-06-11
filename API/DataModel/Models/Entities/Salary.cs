using DataModel.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Salary : BaseEntity
    {
        [Column("SalaryId")]
        public Guid Id { get; set; }
        public string Grade { get; set; }
        public string Position { get; set; }
        public double Growth { get; set; }
        public double Pension { get; set; }
        public double Tax { get; set; }
        public double Allowance { get; set; }
        public double Net { get; set; }
    }
}
