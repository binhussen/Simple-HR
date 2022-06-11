using DataModel.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Department : BaseEntity
    {
        [Column("DepartmentId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
