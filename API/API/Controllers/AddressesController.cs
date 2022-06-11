using Contracts.Interfaces;
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
        public AddressesController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var addresses = await _repository.Address.GetAllAddressesAsync( trackChanges: false);
            return Ok(addresses);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _repository.Address.GetAddressAsync(id, trackChanges: false);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _repository.Address.CreateAddress(address);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] Address address)
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
            addressEntity.Country = address.Country;
            addressEntity.City=address.City;
            addressEntity.Street=address.Street;
            addressEntity.Website=  address.Website;
            addressEntity.Phone=    address.Phone;
            addressEntity.Email= address.Email;
            addressEntity.Fax= address.Fax;

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
