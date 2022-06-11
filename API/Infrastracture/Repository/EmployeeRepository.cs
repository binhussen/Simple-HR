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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployee
    {
        public EmployeeRepository(HrDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.FirstName)
           .ToListAsync();
    }
}
