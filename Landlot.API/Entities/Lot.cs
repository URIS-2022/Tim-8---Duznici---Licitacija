using Landlot.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Landlot.API.Entities
{
    /// <summary>
    /// Represents an individual lot within a larger piece of land with various attributes such as boundaries, ownership, and permitted uses.
    /// Implements the IValidatableObject interface for custom validation logic.
    /// </summary>
    public class Lot : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for the lot.
        /// </summary>
        [Key]
        public Guid LotGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the landlot that the lot belongs to.
        /// </summary>
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the area of the lot in square meters.
        /// </summary>

        public decimal LotArea { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who owns the lot.
        /// </summary>
        public Guid LotUser { get; set; }

        /// <summary>
        /// Gets or sets the unique number or identifier of the lot within the landlot.
        /// </summary>
        public int LotNumber { get; set; }

        /// <summary>
        /// Gets or sets the cultural state of the landlot, which may affect its use or development.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture CultureState { get; set; }

        /// <summary>
        /// Gets or sets the class state of the landlot, which may affect its use or development.
        /// </summary>

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass ClassState { get; set; }

        /// <summary>
        /// Gets or sets the processing state of the landlot, which may indicate its readiness for development or sale.
        /// </summary>
        /// 
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing ProcessingState { get; set; }

        /// <summary>
        /// Gets or sets the protected zone state of the landlot, which may affect its use or development.
        /// </summary>

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone ProtectedZoneState { get; set; }

        /// <summary>
        /// Gets or sets the drainage state of the landlot, which may affect its suitability for development or agricultural use.
        /// </summary>

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage DrainageState { get; set; }

        /// <summary>
        /// Gets or sets the Land object associated with the Lot.
        /// </summary>
        public Land? Land { get; set; }

        /// <summary>
        /// Validates the Lot object and returns a collection of any validation errors.
        /// </summary>
        /// <param name="validationContext">The context in which the validation is being performed.</param>
        /// <returns>
        /// A collection of ValidationResult objects that represent the validation errors detected on the Lot object.
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (LotArea <= 0)
            {
                results.Add(new ValidationResult("Lot area must be greater than 0.", new[] { "LotArea" }));
            }

            if (LotNumber <= 0)
            {
                results.Add(new ValidationResult("Lot number must be greater than 0.", new[] { "LotNumber" }));
            }

            if (!Enum.IsDefined(typeof(LandlotCulture), CultureState) || CultureState.Equals(default(LandlotCulture)))
            {
                results.Add(new ValidationResult("Culture state cannot be null.", new[] { "CultureState" }));
            }
            if (!Enum.IsDefined(typeof(LandlotClass), ClassState) || ClassState.Equals(default(LandlotClass)))
            {
                results.Add(new ValidationResult("Class state cannot be null.", new[] { "ClassState" }));
            }

            if (!Enum.IsDefined(typeof(LandlotProcessing), ProcessingState) || ProcessingState.Equals(default(LandlotProcessing)))
            {
                results.Add(new ValidationResult("Processing state cannot be null.", new[] { "ProcessingState" }));
            }

            if (!Enum.IsDefined(typeof(LandlotProtectedZone), ProtectedZoneState) || ProtectedZoneState.Equals(default(LandlotProtectedZone)))
            {
                results.Add(new ValidationResult("Protected zone state cannot be null.", new[] { "ProtectedZoneState" }));
            }

            if (!Enum.IsDefined(typeof(LandlotDrainage), DrainageState) || DrainageState.Equals(default(LandlotDrainage)))
            {
                results.Add(new ValidationResult("Drainage state cannot be null.", new[] { "DrainageState" }));
            }

            if (Land == null)
            {
                results.Add(new ValidationResult("Land cannot be null.", new[] { "Land" }));
            }

            return results;
        }

    }
}

