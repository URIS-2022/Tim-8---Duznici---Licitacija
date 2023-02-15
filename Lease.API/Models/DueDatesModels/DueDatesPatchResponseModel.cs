
using System.Runtime.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePatchResponseModel
{
 
    [DataMember]
    public DateTime? Date { get; set; }



    public DueDatePatchResponseModel( DateTime date)
    {
  
        Date = date;
    }
}