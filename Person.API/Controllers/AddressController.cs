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
    public async Task<ActionResult<IEnumerable<Address?>>> GetAddress()
    {
        var addresses = await addressRepository.GetAllAddress();
        if (!addresses.Any())
        {
            return NoContent();
        }
        IEnumerable<Address> responseModels = mapper.Map<IEnumerable<Address>>(addresses);
        return Ok(responseModels);
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
        return CreatedAtAction("GetAddresses", new { addressId = createdAddress.AddressId }, responseModel);
    }


    [HttpDelete("{addressId}")]
    public async Task<IActionResult> DeleteAddress(Guid addressId)
    {
        Address? address = await addressRepository.GetAddressByGuid(addressId);
        if (address == null)
        {
            return NotFound();
        }
        await addressRepository.DeleteAddress(address.AddressId);

        return NoContent();
    }
}