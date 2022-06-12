using AutoMapper;
using Contracts.Interfaces;
using DataModel.Models.Dtos;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public AddressesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var addresses = await _repository.Address.GetAllAddressesAsync( trackChanges: false);
            var addressDtos = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            return Ok(addressDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _repository.Address.GetAddressAsync(id, trackChanges: false);
            if (address == null)
            {
                return NotFound();
            }
            var addressDto = _mapper.Map<AddressDto>(address);
            return Ok(addressDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressForCreationDto address)
        {
            if (address == null)
            {
                return BadRequest("Address object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var addressEntity = _mapper.Map<Address>(address);
            _repository.Address.CreateAddress(addressEntity);
            await _repository.SaveAsync();

            var addressToReturn = _mapper.Map<AddressDto>(addressEntity);
            return CreatedAtRoute(new { id = addressToReturn.Id }, addressToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressForUpdateDto address)
        {
            if (address == null)
            {
                return BadRequest("Address object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var addressEntity = await _repository.Address.GetAddressAsync(id, trackChanges: true);
            if (addressEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(address, addressEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _repository.Address.GetAddressAsync(id, trackChanges: false);
            if (address == null)
            {
                return NotFound();
            }

            _repository.Address.DeleteAddress(address);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
