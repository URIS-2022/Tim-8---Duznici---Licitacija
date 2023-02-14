using Landlot.API.Enums;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Entities
{
    public class Lot : IValidatableObject
    {
        [Key]
        public Guid LotGuid { get; set; }

        public Guid LandGuid { get; set; }

        public decimal LotArea { get; set; }

        public Guid LotUser { get; set; }

        public int LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture CultureState { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass ClassState { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing ProcessingState { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone ProtectedZoneState { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage DrainageState { get; set; }

        public Land? Land { get; set; }

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

