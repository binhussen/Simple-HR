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
    public class SalaryRepository : RepositoryBase<Salary>, ISalary
    {
        public SalaryRepository(HrDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateSalary(Salary salary)
        {
            Create(salary);
        }

        public void DeleteSalary(Salary salary)
        {
            Delete(salary);
        }

        public async Task<Salary> GetSalaryAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public async Task<IEnumerable<Salary>> GetAllSalaryesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.Net)
           .ToListAsync();

        public Task<IEnumerable<Salary>> GetAllSalarysAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
