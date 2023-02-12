using System.Runtime.Serialization;

namespace Licitation.API.Models.LicitationPBResponse;

[DataContract(Name = "PublicBIdding", Namespace = "")]
public class LicitationPublicBiddingResponse
{
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

    public LicitationPublicBiddingResponse(Guid publicBiddingGuid)
    {
        PublicBiddingGuid = publicBiddingGuid;
    }
}
