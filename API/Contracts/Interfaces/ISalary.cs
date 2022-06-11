using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ISalary
    {
        Task<IEnumerable<Salary>> GetAllSalarysAsync(bool trackChanges);
        Task<Salary> GetSalaryAsync(Guid salaryId, bool trackChanges);
        void CreateSalary(Salary salary);
        void DeleteSalary(Salary salary);
    }
}
