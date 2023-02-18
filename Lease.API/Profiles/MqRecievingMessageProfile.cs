/*namespace Lease.API.Profiles
{
    public class MqRecievingMessageProfile
    {
    CreateMap<LeaseAgreementPatchRequestModel, LeaseAgreement>()
    .ForMember(dest => dest.BestBuyerGuid, opt => opt.Condition(src => src.BestBuyerGuid.HasValue()))

    }
}
*/