
using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePatchResponseModel
{
    [DataMember]
    public Guid? Guid { get; set; }

    [DataMember]
    public DateTime? Date { get; set; }

    DueDatePatchResponseModel() { }

    public DueDatePatchResponseModel(Guid guid, DateTime date)
    {
        Guid = guid;
        Date = date;
    }
}