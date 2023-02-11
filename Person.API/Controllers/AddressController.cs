using Person.API.Data.Repository;
using Person.API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Models.Address;

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



    [HttpPatch("{zipcode}")]
    public async Task<IActionResult> PatchAddress(string zipCode, AddressUpdateModel addressUpdate)
    {
        var address = await addressRepository.GetAddressByZipCode(zipCode);
        if (address == null || addressUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(addressUpdate, address);

        await addressRepository.UpdateAddresses(address);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<AddressModel>> PostAddress(AddressCreationModel requestAddress)
    {
        Address address = mapper.Map<Address>(requestAddress);
        Address? createdAddress = await addressRepository.CreateAddress(address);
        if (address == null)
        {
            return BadRequest();
        }
        AddressModel responseModel = mapper.Map<AddressModel>(createdAddress);
        return CreatedAtAction("GetAddresses", new { addressId = createdAddress.AddressId }, responseModel);
    }


    [HttpDelete("{zipCode}")]
    public async Task<IActionResult> DeleteAddress(string zipCode)
    {
        Address? address = await addressRepository.GetAddressByZipCode(zipCode);
        if (address == null)
        {
            return NotFound();
        }
        await addressRepository.DeleteAddresses(address.AddressId);

        return NoContent();
    }
}