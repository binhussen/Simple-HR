using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(bool trackChanges);
        Task<Department> GetDepartmentAsync(Guid departmentId, bool trackChanges);
        void CreateDepartment(Department department);
        void DeleteDepartment(Department department);
    }
}
