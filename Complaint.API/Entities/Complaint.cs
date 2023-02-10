using Complaint.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Complaint.API.Entities
{
    public class Complaint : IValidatableObject
    {
        public Guid Guid { get; set; }
        [JsonConverter(typeof(ComplaintTypeConverter))]
        public ComplaintType Type { get; set; }
        public DateOnly DateSubmitted { get; set; }
        public Guid BuyerGuid { get; set; }
        public string Reason { get; set; }
        public string Rationale { get; set; }
        public DateOnly ResolutionDate { get; set; }
        public string ResolutionCode { get; set; }
        [JsonConverter(typeof(ComplaintStatusConverter))]
        public  ComplaintStatus Status { get; set; }
        public Guid SubjectGuid { get; set; }
        [JsonConverter(typeof(ComplaintActionConverter))]
        public ComplaintAction Action { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
