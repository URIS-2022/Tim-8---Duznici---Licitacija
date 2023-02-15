using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePatchRequestModel
{
    
    public Guid? Guid { get; set; }

    
    public DateTime? Date { get; set; }

    public DueDatePatchRequestModel() { }

    public DueDatePatchRequestModel(Guid guid, DateTime date)
    {
        Guid = guid;
        Date = date;
    }
}