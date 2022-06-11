using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);
        Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
