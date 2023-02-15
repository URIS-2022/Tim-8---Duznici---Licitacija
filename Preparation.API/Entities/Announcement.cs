using System.ComponentModel.DataAnnotations;

namespace Preparation.API.Entities
{
    public partial class Announcement : IValidatableObject
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid LicitationGuid { get; set; }

        //public List<Document> Documents { get; set; }

        //public Announcement() { }

        public Announcement(Guid id, Guid licitationGuid)
        {
            Guid = id;
            LicitationGuid = licitationGuid;
        }

        public Announcement(Guid licitationGuid)
        {
            Guid = Guid.NewGuid();
            LicitationGuid = licitationGuid;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (LicitationGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            return results;
        }
    }
}
