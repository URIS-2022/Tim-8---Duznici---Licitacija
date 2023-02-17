using Lease.API.Entities;
using Lease.API.Models;
using AutoMapper;

namespace Lease.API.Profiles;

public class DueDateProfile : Profile
{
    public DueDateProfile()
    {
        CreateMap<DueDate, DueDateGetResponseModel>();
        CreateMap<DueDate, DueDatePostResponseModel>();
        CreateMap<DueDate, DueDatePatchResponseModel>();
        CreateMap<DueDatePostRequestModel, DueDate>();
        CreateMap<DueDatePatchRequestModel, DueDate>()
            .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date != null));


    }
}
