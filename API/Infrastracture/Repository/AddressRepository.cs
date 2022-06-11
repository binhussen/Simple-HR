using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddress
    {
        public AddressRepository(HrDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateAddress(Address address)
        {
            Create(address);
        }

        public void DeleteAddress(Address address)
        {
            Delete(address);
        }

        public async Task<Address> GetAddressAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public async Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.Country)
           .ToListAsync();

    }
}
