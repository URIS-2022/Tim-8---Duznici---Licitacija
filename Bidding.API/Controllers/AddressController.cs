using Bidding.API.Data.Repository;
using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressNewResponseModel>>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAllAddresses();
            if (!addresses.Any())
            {
                return NoContent();
            }
            IEnumerable<AddressNewResponseModel> responseModels = _mapper.Map<IEnumerable<AddressNewResponseModel>>(addresses);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<AddressNewResponseModel>> GetAddress(Guid guid)
        {
            Address address = await _addressRepository.GetAddressByGuid(guid);
            if (address == null)
            {
                return NotFound();
            }
            AddressNewResponseModel responseModel = _mapper.Map<AddressNewResponseModel>(address);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<AddressNewResponseModel>> PostAddress(AddressRequestModel requestModel)
        {
            Address address = _mapper.Map<Address>(requestModel);
            Address createdAddress = await _addressRepository.AddAddress(address);
            if (createdAddress == null)
            {
                return BadRequest();
            }
            AddressNewResponseModel responseModel = _mapper.Map<AddressNewResponseModel>(createdAddress);
            return CreatedAtAction("GetAddress", new { guid = createdAddress.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchAddress(Guid guid, AddressUpdateModel addressUpdate)
        {
            var address = await _addressRepository.GetAddressByGuid(guid);
            if (address == null || addressUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(addressUpdate, address);

            var updatedAddress = await _addressRepository.UpdateAddress(address);
            if (updatedAddress == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAddress(Guid guid)
        {
            var address = await _addressRepository.GetAddressByGuid(guid);
            if (address == null)
            {
                return NotFound();
            }

            await _addressRepository.DeleteAddress(guid);

            return NoContent();
        }
    }
}
