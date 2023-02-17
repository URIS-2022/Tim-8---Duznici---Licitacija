
using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePostRequestModel
{

    [DataMember]
    public DateTime Date { get; set; }

    public DueDatePostRequestModel() { }

    public DueDatePostRequestModel(DateTime date)
    {
       
        Date = date;
    }
}