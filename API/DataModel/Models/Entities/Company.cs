using DataModel.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Company : BaseEntity
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid AddressID{ get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
