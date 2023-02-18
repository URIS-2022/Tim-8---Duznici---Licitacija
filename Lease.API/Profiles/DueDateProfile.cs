using AutoMapper;
using Lease.API.Entities;
using Lease.API.Models;

namespace Lease.API.Profiles;

/// <summary>
/// The profile for mapping between entities and response/request models for due dates.
/// </summary>
public class DueDateProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DueDateProfile"/> class.
    /// </summary>
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
