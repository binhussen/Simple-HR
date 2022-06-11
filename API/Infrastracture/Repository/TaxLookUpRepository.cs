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
    public class TaxLookUpRepository : RepositoryBase<TaxLookUp>, ITaxLookUp
    {
        public TaxLookUpRepository(HrDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateTaxLookUp(TaxLookUp taxLookUp)
        {
            Create(taxLookUp);
        }

        public void DeleteTaxLookUp(TaxLookUp taxLookUp)
        {
            Delete(taxLookUp);
        }

        public async Task<TaxLookUp> GetTaxLookUpAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public async Task<IEnumerable<TaxLookUp>> GetAllTaxLookUpsAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.Min)
           .ToListAsync();
    }
}
