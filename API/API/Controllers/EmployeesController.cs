using Contracts.Interfaces;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        public EmployeesController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _repository.Employee.GetAllEmployeesAsync(trackChanges: false);
            return Ok(employees);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(id, trackChanges: false);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _repository.Employee.CreateEmployee(employee);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var employeeEntity = await _repository.Employee.GetEmployeeAsync(id, trackChanges: true);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            employeeEntity.FirstName = employee.FirstName;
            employeeEntity.LastName = employee.LastName;
            employeeEntity.Gander = employee.Gander;
            employeeEntity.BirthDate = employee.BirthDate;
            employeeEntity.HireDate = employee.HireDate;
            employeeEntity.Status = employee.Status;
            employeeEntity.Phone = employee.Phone;
            employeeEntity.Email = employee.Email;
            employeeEntity.SalaryId = employee.SalaryId;
            employeeEntity.DepartmentId = employee.DepartmentId;

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(id, trackChanges: false);
            if (employee == null)
            {
                return NotFound();
            }

            _repository.Employee.DeleteEmployee(employee);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
