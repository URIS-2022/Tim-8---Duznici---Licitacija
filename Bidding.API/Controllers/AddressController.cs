using AutoMapper;
using Bidding.API.Data.Repository;
using Bidding.API.Entities;
using Bidding.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{

    /// <summary>
    /// Controller for managing address data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructs a new instance of the AddressController class.
        /// </summary>
        /// <param name="addressRepository">The repository for working with address data.</param>
        /// <param name="mapper">The AutoMapper instance used for mapping between address models and entities.</param>

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>A list of all addresses in the form of AddressNewResponseModel.</returns>

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

        /// <summary>
        /// Gets an address by its unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier of the address to retrieve.</param>
        /// <returns>The requested address in the form of AddressNewResponseModel.</returns>

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

        /// <summary>
        /// Adds a new address.
        /// </summary>
        /// <param name="requestModel">The model representing the new address to add.</param>
        /// <returns>The newly created address in the form of AddressNewResponseModel.</returns>

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

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="guid">The unique identifier of the address to update.</param>
        /// <param name="addressUpdate">The model representing the updated address data.</param>
        /// <returns>A status code indicating the result of the update operation.</returns>

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

        /// <summary>
        /// Deletes an address with the specified GUID.
        /// </summary>
        /// <param name="guid">The GUID of the address to delete.</param>
        /// <returns>A NoContentResult if the address was successfully deleted.</returns>

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
