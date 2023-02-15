
using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePostRequestModel
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public DateTime Date { get; set; }



    public DueDatePostRequestModel(int id, DateTime date)
    {
        Id = id;
        Date = date;
    }
}