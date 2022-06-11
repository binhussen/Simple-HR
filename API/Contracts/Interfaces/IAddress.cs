using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IAddress
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges);
        Task<Address> GetAddressAsync(int addressId, bool trackChanges);
        void CreateAddress(Address address);
        void DeleteAddress(Address address);
    }
}
