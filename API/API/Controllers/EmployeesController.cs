using AutoMapper;
using Contracts.Interfaces;
using DataModel.Models.Dtos;
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
        private readonly IMapper _mapper;
        public EmployeesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _repository.Employee.GetAllEmployeesAsync(trackChanges: false);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees); 
            return Ok(employeeDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(id, trackChanges: false);
            if (employee == null)
            {
                return NotFound();
            }

            var employeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployee(employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return CreatedAtRoute(new { id = employeeToReturn.Id }, employeeToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeForUpdateDto employee)
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

            _mapper.Map(employee, employeeEntity);

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
