using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IAddress Address { get; }
        ICompany Company { get; }
        IDepartment Department { get; }
        IEmployee Employee { get; }
        ISalary Salary { get; }
        ITaxLookUp TaxLookUp { get; }
        Task SaveAsync();
    }
}
