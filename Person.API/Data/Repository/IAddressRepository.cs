﻿using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddresses();
        Task<Address> GetAddressByGuid(Guid AddressId);
        Task<Address?> GetAddressByZipCode(string zipCode);
        Task<Address> CreateAddress(Address address);
        Task DeleteAddresses(Guid AddressId);
        Task UpdateAddresses(Address address);

    }
}