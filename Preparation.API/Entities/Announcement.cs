using System.ComponentModel.DataAnnotations;

namespace Preparation.API.Entities
{
    /// <summary>
    /// Represents an announcement made for a licitation.
    /// </summary>
    public partial class Announcement : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for the announcement.
        /// </summary>
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the licitation to which the announcement belongs.
        /// </summary>
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// Gets or sets the collection of documents associated with the announcement.
        /// </summary>
        public ICollection<Document> Documents { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Announcement"/> class with the specified unique identifier and licitation identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the announcement.</param>
        /// <param name="licitationGuid">The unique identifier for the licitation to which the announcement belongs.</param>
        public Announcement(Guid id, Guid licitationGuid)
        {
            Guid = id;
            LicitationGuid = licitationGuid;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Announcement"/> class with a new unique identifier and the specified licitation identifier.
        /// </summary>
        /// <param name="licitationGuid">The unique identifier for the licitation to which the announcement belongs.</param>
        public Announcement(Guid licitationGuid)
        {
            Guid = Guid.NewGuid();
            LicitationGuid = licitationGuid;
        }

        /// <summary>
        /// Validates the current instance of the <see cref="Announcement"/> class.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection of validation results. The collection is empty if the instance is valid.</returns>
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
