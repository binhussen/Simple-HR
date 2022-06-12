using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Dtos
{
    public class AddressForManipulationDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
