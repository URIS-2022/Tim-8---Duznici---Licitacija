using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDateGetResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

    [DataMember]
    public DateTime Date { get; set; }

    public DueDateGetResponseModel(Guid guid, DateTime date)
    {
        Guid = guid;
        Date = date;
    }
}