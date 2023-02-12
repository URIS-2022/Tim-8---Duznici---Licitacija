using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Landlot.API.Entities
{
    public class Lot : IValidatableObject
    {

        public Guid LotGuid { get; set; }
        public Guid LandGuid { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int LotArea { get; set; }

        public int LotUser { get; set; }

        public int LotNumber { get; set; }

        public string LandCultureState { get; set; }

        public string LandProcessingState { get; set; }

        public string ProtectedZoneState { get; set; }

        public string DrainageState { get; set; }

        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                var results = new List<ValidationResult>();

                // Validate ExpiryDate
                if (ExpiryDate == null)
                {
                    results.Add(new ValidationResult("ExpiryDate is required"));
                }

                // Validate LotArea
                if (LotArea <= 0)
                {
                    results.Add(new ValidationResult("LotArea must be greater than 0"));
                }

                // Validate LotUser
                if (LotUser <= 0)
                {
                    results.Add(new ValidationResult("LotUser must be greater than 0"));
                }

                // Validate LotNumber
                if (LotNumber <= 0)
                {
                    results.Add(new ValidationResult("LotNumber must be greater than 0"));
                }

                // Validate LandCultureState
                if (string.IsNullOrWhiteSpace(LandCultureState))
                {
                    results.Add(new ValidationResult("LandCultureState is required"));
                }
                else if (LandCultureState.Length > 50)
                {
                    results.Add(new ValidationResult("LandCultureState cannot be longer than 50 characters"));
                }

                // Validate LandProcessingState
                if (string.IsNullOrWhiteSpace(LandProcessingState))
                {
                    results.Add(new ValidationResult("LandProcessingState is required"));
                }
                else if (LandProcessingState.Length > 50)
                {
                    results.Add(new ValidationResult("LandProcessingState cannot be longer than 50 characters"));
                }

                // Validate ProtectedZoneState
                if (string.IsNullOrWhiteSpace(ProtectedZoneState))
                {
                    results.Add(new ValidationResult("ProtectedZoneState is required"));
                }
                else if (ProtectedZoneState.Length > 50)
                {
                    results.Add(new ValidationResult("ProtectedZoneState cannot be longer than 50 characters"));
                }

                // Validate DrainageState
                if (string.IsNullOrWhiteSpace(DrainageState))
                {
                    results.Add(new ValidationResult("DrainageState is required"));
                }
                else if (DrainageState.Length > 50)
                {
                    results.Add(new ValidationResult("DrainageState cannot be longer than 50 characters"));
                }

                return results;
            }

        }
    }

