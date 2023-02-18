using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePatchRequestModel
{




    public DateTime? Date { get; set; }

    public DueDatePatchRequestModel() { }

    public DueDatePatchRequestModel(Guid guid, DateTime date)
    {

        Date = date;
    }
}