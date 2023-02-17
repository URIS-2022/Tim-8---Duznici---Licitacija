using Person.API.Data.Repository;
using Person.API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Models;

namespace Person.API.Controllers;
/// <summary>
/// Controller for managing addresses.
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository addressRepository;
    private readonly IMapper mapper;
    /// <summary>
    /// Constructor for the AddressController.
    /// </summary>
    /// <param name="addressRepository">The repository for managing addresses.</param>
    /// <param name="mapper">The mapper for mapping between domain models and DTOs.</param>
    public AddressController(IAddressRepository addressRepository, IMapper mapper)
    {
        this.addressRepository = addressRepository;
        this.mapper = mapper;
    }
    /// <summary>
    /// Returns a list of addresses.
    /// </summary>
    /// <returns>A collection of addresses.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address?>>> GetAddresses()
    {
        var addresses = await addressRepository.GetAllAddresses();
        if (!addresses.Any())
        {
            return NoContent();
        }
        IEnumerable<Address> responseModels = mapper.Map<IEnumerable<Address>>(addresses);
        return Ok(responseModels);
    }
    /// <summary>
    /// Returns the address with the specified id.
    /// </summary>
    /// <param name="AddressId">The ID of the address to get.</param>
    /// <returns>The address with the specified ID, or NotFound if no such address exists.</returns>
    [HttpGet("{AddressId}")]
    public async Task<ActionResult<AddressResponseModel>> GetAddress(Guid AddressId)
    {
        var address = await addressRepository.GetAddressByGuid(AddressId);
        if (address == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<AddressResponseModel>(address);
        return responseModel;
    }
    /// <summary>
    /// Updates an address with the specified id.
    /// </summary>
    /// <param name="id">The ID of the address to update.</param>
    /// <param name="patchModel">The address information to update.</param>
    /// <returns>The updated address, or NotFound if no such address exists, or BadRequest if the update fails.</returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<AddressResponseModel>> PatchAddress(Guid id, [FromBody] AddressRequestModel patchModel)
    {
        var address = await addressRepository.GetAddressByGuid(id);
        if (address == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, address);

        var updated = await addressRepository.UpdateAddress(id, address);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<AddressResponseModel>(updated);

        return Ok(responseModel);
    }
    /// <summary>
    /// Creates a new address.
    /// </summary>
    /// <param name="requestAddress">The information for the new address.</param>
    /// <returns>The newly created address, or BadRequest if the address creation fails.</returns>

    [HttpPost]
    public async Task<ActionResult<AddressResponseModel>> PostAddress(AddressRequestModel requestAddress)
    {
        Address address = mapper.Map<Address>(requestAddress);
        Address? createdAddress = await addressRepository.CreateAddress(address);
        if (address == null)
        {
            return BadRequest();
        }
        AddressResponseModel responseModel = mapper.Map<AddressResponseModel>(createdAddress);
        return CreatedAtAction("GetAddresses", new { street = responseModel.Street }, responseModel);
    }
    /// <summary>
    /// Deletes the address with the specified id.
    /// </summary>
    /// <param name="id">The ID of the address to delete.</param>
    /// <returns>NoContent if the address is deleted successfully, or NotFound if no such address exists.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(Guid id)
    {
        var address = await addressRepository.GetAddressByGuid(id);
        if (address == null)
        {
            return NotFound();
        }
        await addressRepository.DeleteAddress(address.AddressId);

        return NoContent();
    }
}