using Contracts.Interfaces;
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
        public SalariesController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaries = await _repository.Salary.GetAllSalariesAsync(trackChanges: false);
            return Ok(salaries);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalary(int id)
        {
            var salary = await _repository.Salary.GetSalaryAsync(id, trackChanges: false);
            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalary([FromBody] Salary salary)
        {
            if (salary == null)
            {
                return BadRequest("Salary object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _repository.Salary.CreateSalary(salary);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromBody] Salary salary)
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

            salaryEntity.Grade = salary.Grade;
            salaryEntity.Position = salary.Position;
            salaryEntity.Growth = salary.Growth;
            salaryEntity.Pension = salary.Pension;
            salaryEntity.Tax = salary.Tax;
            salaryEntity.Allowance = salary.Allowance;
            salaryEntity.Net = salary.Net;

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
