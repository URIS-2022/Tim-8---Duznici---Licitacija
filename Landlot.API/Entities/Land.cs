using Landlot.API.Entities;
using Landlot.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Landlot.API.Entities
{
    public class Land : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for a land record.
        /// </summary>
        [Key]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the total area of the land in square meters.
        /// </summary>
        public decimal TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality in which the landlot is located.
        /// </summary>
        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        public LandlotMunicipality Municipality { get; set; }

        /// <summary>
        /// Gets or sets the RealSstateNumber of the landlot.
        /// </summary>
        public string? RealEstateNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture of the landlot.
        /// </summary>

        [JsonConverter(typeof(LandlotCultureConverter))]

        public LandlotCulture Culture { get; set; }

        /// <summary>
        /// Gets or sets the class of the landlot.
        /// </summary>

        [JsonConverter(typeof(LandlotClassConverter))]

        public LandlotClass LandClass { get; set; }

        /// <summary>
        /// Gets or sets the public LandlotProcessing object used for processing landlot data.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing Processing { get; set; }

        /// <summary>
        /// Gets or sets the public LandlotProtectedZone object used for managing protected zones within the landlot.
        /// </summary>
        /// 
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone Zone { get; set; }

        /// <summary>
        /// Gets or sets the public LandlotPropertyType object used for managing property types within the landlot.
        /// </summary>

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType Property { get; set; }

        /// <summary>
        /// Gets or sets the public LandlotDrainage object used for managing drainage systems within the landlot.
        /// </summary>
        /// 
        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage Drainage { get; set; }

        /// <summary>
        /// Gets or sets a list of Lot objects representing the individual lots within the landlot.
        /// </summary>
        /// <remarks>
        /// This property can be used to access and manipulate information about each lot within the landlot,
        /// such as its boundaries, ownership, and permitted uses.
        /// </remarks>
        public List<Lot>? Lots { get; set; }

        /// <summary>
        /// Validates the Landlot object using the specified validation context and returns a collection of validation results.
        /// </summary>
        /// <param name="validationContext">The validation context used for validation.</param>
        /// <returns>An IEnumerable of ValidationResult objects representing the validation errors, if any.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (TotalArea < 0)
            {
                results.Add(new ValidationResult("TotalArea must be a positive value."));
            }

            if (!Enum.IsDefined(typeof(LandlotMunicipality), Municipality) || Municipality.Equals(default(LandlotMunicipality)))
            {
                results.Add(new ValidationResult("Municipality is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotCulture), Culture) || Culture.Equals(default(LandlotCulture)))
            {
                results.Add(new ValidationResult("Culture is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotClass), LandClass) || LandClass.Equals(default(LandlotClass)))
            {
                results.Add(new ValidationResult("LandClass is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotProcessing), Processing) || Processing.Equals(default(LandlotProcessing)))
            {
                results.Add(new ValidationResult("Processing is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotProtectedZone), Zone) || Zone.Equals(default(LandlotProtectedZone)))
            {
                results.Add(new ValidationResult("Protected zone is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotPropertyType), Property) || Property.Equals(default(LandlotPropertyType)))
            {
                results.Add(new ValidationResult("Property type is required."));
            }

            if (!Enum.IsDefined(typeof(LandlotDrainage), Drainage) || Drainage.Equals(default(LandlotDrainage)))
            {
                results.Add(new ValidationResult("Drainage state is required."));
            }

            return results;
        }

    }
}


    