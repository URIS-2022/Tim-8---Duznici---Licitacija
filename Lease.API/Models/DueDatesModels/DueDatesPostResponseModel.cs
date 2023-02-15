using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePostResponseModel
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public DateTime Date { get; set; }



    public DueDatePostResponseModel(int id,DateTime date)
    {
        Id= id;
        Date = date;
    }
}