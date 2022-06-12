using AutoMapper;
using Contracts.Interfaces;
using DataModel.Models.Dtos;
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
        private readonly IMapper _mapper;
        public TaxLookUpsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaxLookUps()
        {
            var taxLookUps = await _repository.TaxLookUp.GetAllTaxLookUpsAsync(trackChanges: false);
            var taxLookUpDtos = _mapper.Map<IEnumerable<TaxLookUpDto>>(taxLookUps); 
            return Ok(taxLookUpDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxLookUp(int id)
        {
            var taxLookUp = await _repository.TaxLookUp.GetTaxLookUpAsync(id, trackChanges: false);
            if (taxLookUp == null)
            {
                return NotFound();
            }
            var taxLookUpDto = _mapper.Map<TaxLookUpDto>(taxLookUp);
            return Ok(taxLookUpDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaxLookUp([FromBody] TaxLookUpForCreationDto taxLookUp)
        {
            if (taxLookUp == null)
            {
                return BadRequest("TaxLookUp object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var taxLookUpEntity = _mapper.Map<TaxLookUp>(taxLookUp);
            _repository.TaxLookUp.CreateTaxLookUp(taxLookUpEntity);
            await _repository.SaveAsync();

            var taxLookUpToReturn = _mapper.Map<TaxLookUpDto>(taxLookUpEntity);
            return CreatedAtRoute(new { id = taxLookUpToReturn.Id }, taxLookUpToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxLookUp(int id, [FromBody] TaxLookUpForUpdateDto taxLookUp)
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

            _mapper.Map(taxLookUp, taxLookUpEntity);

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
