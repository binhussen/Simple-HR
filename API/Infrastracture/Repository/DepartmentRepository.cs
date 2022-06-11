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
    public class DepartmentRepository : RepositoryBase<Department>, IDepartment
    {
        public DepartmentRepository(HrDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateDepartment(Department department)
        {
            Create(department);
        }

        public void DeleteDepartment(Department department)
        {
            Delete(department);
        }

        public async Task<Department> GetDepartmentAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public async Task<IEnumerable<Department>> GetAllDepartmentesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToListAsync();

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
