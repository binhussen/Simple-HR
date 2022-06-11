using Contracts.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly HrDbContext _repositoryContext;
        private IAddress _addressRepository;
        private ICompany _companyRepository;
        private IDepartment _departmentRepository;
        private IEmployee _employeeRepository;
        private ISalary _salaryRepository;
        private ITaxLookUp _taxLookUpRepository;

        public RepositoryManager(HrDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAddress Address
        {
            get
            {
                if (_addressRepository == null)
                    _addressRepository = new AddressRepository(_repositoryContext);

                return _addressRepository;
            }
        }
        public ICompany Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);

                return _companyRepository;
            }
        }

        public IDepartment Department
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_repositoryContext);

                return _departmentRepository;
            }
        }
        public IEmployee Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);

                return _employeeRepository;
            }
        }
        public ISalary Salary
        {
            get
            {
                if (_salaryRepository == null)
                    _salaryRepository = new SalaryRepository(_repositoryContext);

                return _salaryRepository;
            }
        }
        public ITaxLookUp TaxLookUp
        {
            get
            {
                if (_taxLookUpRepository == null)
                    _taxLookUpRepository = new TaxLookUpRepository(_repositoryContext);

                return _taxLookUpRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
