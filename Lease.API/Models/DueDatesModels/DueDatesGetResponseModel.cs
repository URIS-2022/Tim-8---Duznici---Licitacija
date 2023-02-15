using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDateGetResponseModel
{
    

    [DataMember]
    public DateTime Date { get; set; }

    

    public DueDateGetResponseModel(DateTime date)
    {
        Date = date;
    }
}