using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ITaxLookUp
    {
        Task<IEnumerable<TaxLookUp>> GetAllTaxLookUpsAsync(bool trackChanges);
        Task<TaxLookUp> GetTaxLookUpAsync(Guid taxLookUpId, bool trackChanges);
        void CreateTaxLookUp(TaxLookUp taxLookUp);
        void DeleteTaxLookUp(TaxLookUp taxLookUp);
    }
}
