using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Common
{
    public class BaseEntity
    {
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
