using System.ComponentModel.DataAnnotations;

namespace Landlot.API.Entities
{
    public class Land : IValidatableObject
    {
        public Guid LandGuid { get; set; }

        public int TotalArea { get; set; }

        public string MunicipalityId { get; set; }

        public string NameOfTheMunicipality { get; set; }

        public string RealEstateNumber { get; set; }

        public string LandCulture { get; set; }

        public string LandClass { get; set; }

        public string LandProcessing { get; set; }

        public string ProtectedZone { get; set; }

        public string PropertyType { get; set; }

        public Guid Drainage { get; set; }

       

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Validate TotalArea
            if (TotalArea <= 0)
            {
                results.Add(new ValidationResult("TotalArea must be greater than 0"));
            }

            // Validate MunicipalityId
            if (string.IsNullOrWhiteSpace(MunicipalityId))
            {
                results.Add(new ValidationResult("MunicipalityId is required"));
            }
            else if (MunicipalityId.Length > 50)
            {
                results.Add(new ValidationResult("MunicipalityId cannot be longer than 50 characters"));
            }

            // Validate NameOfTheMunicipality
            if (string.IsNullOrWhiteSpace(NameOfTheMunicipality))
            {
                results.Add(new ValidationResult("NameOfTheMunicipality is required"));
            }
            else if (NameOfTheMunicipality.Length > 50)
            {
                results.Add(new ValidationResult("NameOfTheMunicipality cannot be longer than 50 characters"));
            }

            // Validate RealEstateNumber
            if (string.IsNullOrWhiteSpace(RealEstateNumber))
            {
                results.Add(new ValidationResult("RealEstateNumber is required"));
            }
            else if (RealEstateNumber.Length > 50)
            {
                results.Add(new ValidationResult("RealEstateNumber cannot be longer than 50 characters"));
            }

            // Validate LandCulture
            if (string.IsNullOrWhiteSpace(LandCulture))
            {
                results.Add(new ValidationResult("LandCulture is required"));
            }
            else if (LandCulture.Length > 50)
            {
                results.Add(new ValidationResult("LandCulture cannot be longer than 50 characters"));
            }

            // Validate LandClass
            if (string.IsNullOrWhiteSpace(LandClass))
            {
                results.Add(new ValidationResult("LandClass is required"));
            }
            else if (LandClass.Length > 50)
            {
                results.Add(new ValidationResult("LandClass cannot be longer than 50 characters"));
            }

            // Validate LandProcessing
            if (string.IsNullOrWhiteSpace(LandProcessing))
            {
                results.Add(new ValidationResult("LandProcessing is required"));
            }
            else if (LandProcessing.Length > 50)
            {
                results.Add(new ValidationResult("LandProcessing cannot be longer than 50 characters"));
            }

            // Validate ProtectedZone
            if (string.IsNullOrWhiteSpace(ProtectedZone))
            {
                results.Add(new ValidationResult("ProtectedZone is required"));
            }
            else if (ProtectedZone.Length > 50)
            {
                results.Add(new ValidationResult("ProtectedZone cannot be longer than 50 characters"));
            }

            // Validate PropertyType
            if (string.IsNullOrWhiteSpace(PropertyType))
            {
                results.Add(new ValidationResult("PropertyType is required"));
            }
            else if (PropertyType.Length > 50)
            {
                results.Add(new ValidationResult("PropertyType cannot be longer than 50 characters"));
            }

            // Validate Drainage
            if (Drainage == Guid.Empty)
            {
                results.Add(new ValidationResult("Drainage is required"));
            }

            return results;
        }


    }
}
