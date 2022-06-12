using AutoMapper;
using Contracts.Interfaces;
using DataModel.Models.Dtos;
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
        private readonly IMapper _mapper;
        public DepartmentsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _repository.Department.GetAllDepartmentsAsync(trackChanges: false);
            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments); 
            return Ok(departmentDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _repository.Department.GetDepartmentAsync(id, trackChanges: false);
            if (department == null)
            {
                return NotFound();
            }

            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentForCreationDto department)
        {
            if (department == null)
            {
                return BadRequest("Department object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var departmentEntity = _mapper.Map<Department>(department);
            _repository.Department.CreateDepartment(departmentEntity);
            await _repository.SaveAsync();

            var departmentToReturn = _mapper.Map<DepartmentDto>(departmentEntity);
            return CreatedAtRoute(new { id = departmentToReturn.Id }, departmentToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentForUpdateDto department)
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

            _mapper.Map(department, departmentEntity);

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
