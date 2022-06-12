using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Dtos
{
    public class SalaryDto
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public string Position { get; set; }
        public double Growth { get; set; }
        public double Pension { get; set; }
        public double Tax { get; set; }
        public double Allowance { get; set; }
        public double Net { get; set; }
    }
}
