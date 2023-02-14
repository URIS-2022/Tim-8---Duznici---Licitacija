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
        [Key]
        public Guid LandGuid { get; set; }

        public decimal TotalArea { get; set; }

        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        public LandlotMunicipality Municipality { get; set; }

        public string RealEstateNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture Culture { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass LandClass { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing Processing { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone Zone { get; set; }

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType Property { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage Drainage { get; set; }

        public List<Lot> Lots { get; set; }

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


    