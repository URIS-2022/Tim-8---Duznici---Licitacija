using Person.API.Data.Repository;
using Person.API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Models;

namespace Person.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository addressRepository;
    private readonly IMapper mapper;

    public AddressController(IAddressRepository addressRepository, IMapper mapper)
    {
        this.addressRepository = addressRepository;
        this.mapper = mapper;
    }

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