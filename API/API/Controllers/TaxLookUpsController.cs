using Contracts.Interfaces;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/taxlookups")]
    [ApiController]
    public class TaxLookUpsController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        public TaxLookUpsController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaxLookUps()
        {
            var taxLookUps = await _repository.TaxLookUp.GetAllTaxLookUpsAsync(trackChanges: false);
            return Ok(taxLookUps);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxLookUp(int id)
        {
            var taxLookUp = await _repository.TaxLookUp.GetTaxLookUpAsync(id, trackChanges: false);
            if (taxLookUp == null)
            {
                return NotFound();
            }

            return Ok(taxLookUp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaxLookUp([FromBody] TaxLookUp taxLookUp)
        {
            if (taxLookUp == null)
            {
                return BadRequest("TaxLookUp object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _repository.TaxLookUp.CreateTaxLookUp(taxLookUp);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxLookUp(int id, [FromBody] TaxLookUp taxLookUp)
        {
            if (taxLookUp == null)
            {
                return BadRequest("TaxLookUp object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var taxLookUpEntity = await _repository.TaxLookUp.GetTaxLookUpAsync(id, trackChanges: true);
            if (taxLookUpEntity == null)
            {
                return NotFound();
            }

            taxLookUpEntity.Min = taxLookUp.Min;
            taxLookUpEntity.Max = taxLookUp.Max;
            taxLookUpEntity.Parsent = taxLookUp.Parsent;
            taxLookUpEntity.PensionRate = taxLookUp.PensionRate;
            taxLookUpEntity.Deduction = taxLookUp.Deduction;

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxLookUp(int id)
        {
            var taxLookUp = await _repository.TaxLookUp.GetTaxLookUpAsync(id, trackChanges: false);
            if (taxLookUp == null)
            {
                return NotFound();
            }

            _repository.TaxLookUp.DeleteTaxLookUp(taxLookUp);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
