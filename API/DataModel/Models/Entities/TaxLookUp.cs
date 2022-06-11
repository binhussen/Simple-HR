using DataModel.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class TaxLookUp : BaseEntity
    {
        [Column("SalaryId")]
        public int Id { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Parsent { get; set; }
        public double PensionRate { get; set; }
        public double Deduction { get; set; }
    }
}
