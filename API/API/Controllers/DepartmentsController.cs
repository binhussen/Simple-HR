using Contracts.Interfaces;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public DepartmentsController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _repository.Department.GetAllDepartmentsAsync(trackChanges: false);
            return Ok(departments);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _repository.Department.GetDepartmentAsync(id, trackChanges: false);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("Department object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _repository.Department.CreateDepartment(department);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("Department object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var departmentEntity = await _repository.Department.GetDepartmentAsync(id, trackChanges: true);
            if (departmentEntity == null)
            {
                return NotFound();
            }

            departmentEntity.Name = department.Name;
            departmentEntity.Description = department.Description;
            departmentEntity.CompanyId = department.CompanyId;

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _repository.Department.GetDepartmentAsync(id, trackChanges: false);
            if (department == null)
            {
                return NotFound();
            }

            _repository.Department.DeleteDepartment(department);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
