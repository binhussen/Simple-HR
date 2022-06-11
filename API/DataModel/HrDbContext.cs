using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class HrDbContext : DbContext
    {
        public HrDbContext()
        {

        }

        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<TaxLookUp> TaxLookUps { get; set; }
    }
}
