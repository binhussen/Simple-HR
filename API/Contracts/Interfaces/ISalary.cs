﻿using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ISalary
    {
        Task<IEnumerable<Salary>> GetAllSalariesAsync(bool trackChanges);
        Task<Salary> GetSalaryAsync(int salaryId, bool trackChanges);
        void CreateSalary(Salary salary);
        void DeleteSalary(Salary salary);
    }
}
