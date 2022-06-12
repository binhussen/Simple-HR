using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Dtos
{
    public class TaxLookUpDto
    {
        public int Id { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Parsent { get; set; }
        public double PensionRate { get; set; }
        public double Deduction { get; set; }
    }
}
