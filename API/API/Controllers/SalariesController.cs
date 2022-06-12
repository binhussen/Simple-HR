using AutoMapper;
using Contracts.Interfaces;
using DataModel.Models.Dtos;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/salaries")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public SalariesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaries = await _repository.Salary.GetAllSalariesAsync(trackChanges: false);
            var salaryDtos = _mapper.Map<IEnumerable<SalaryDto>>(salaries); 
            return Ok(salaryDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalary(int id)
        {
            var salary = await _repository.Salary.GetSalaryAsync(id, trackChanges: false);
            if (salary == null)
            {
                return NotFound();
            }
            var salaryDto = _mapper.Map<SalaryDto>(salary);
            return Ok(salaryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalary([FromBody] SalaryForCreationDto salary)
        {
            if (salary == null)
            {
                return BadRequest("Salary object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var salaryEntity = _mapper.Map<Salary>(salary);
            _repository.Salary.CreateSalary(salaryEntity);
            await _repository.SaveAsync();

            var salaryToReturn = _mapper.Map<SalaryDto>(salaryEntity);
            return CreatedAtRoute(new { id = salaryToReturn.Id }, salaryToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromBody] SalaryForUpdateDto salary)
        {
            if (salary == null)
            {
                return BadRequest("Salary object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var salaryEntity = await _repository.Salary.GetSalaryAsync(id, trackChanges: true);
            if (salaryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(salary, salaryEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var salary = await _repository.Salary.GetSalaryAsync(id, trackChanges: false);
            if (salary == null)
            {
                return NotFound();
            }

            _repository.Salary.DeleteSalary(salary);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
