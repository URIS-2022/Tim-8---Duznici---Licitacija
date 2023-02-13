﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Payment.API.Entities
{
    public class PaymentEntity : IValidatableObject
    {
        public Guid Guid { get; set; }
        public string AccountNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid PayerGuid { get; set; }
        public string PaymentTitle { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public Guid PaymentWarrantGuid { get; set; }
        public PaymentWarrant paymentWarrant { get; internal set; }

        //public object PaymentWarrant { get; set; }

        public PaymentEntity()
        {
        }

        public PaymentEntity(Guid paymentGuid, string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid, Guid paymentWarrantGuid)
        {
            Guid = paymentGuid;
            AccountNumber = accountNumber;
            ReferenceNumber = referenceNumber;
            TotalAmount = totalAmount;
            PayerGuid = payerGuid;
            PaymentTitle = paymentTitle;
            PaymentDate = paymentDate;
            PublicBiddingGuid = publicBiddingGuid;
            PaymentWarrantGuid = paymentWarrantGuid;
        }

        public PaymentEntity(string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid, Guid paymentWarrantGuid)
        {
            Guid = Guid.NewGuid();
            AccountNumber = accountNumber;
            ReferenceNumber = referenceNumber;
            TotalAmount = totalAmount;
            PayerGuid = payerGuid;
            PaymentTitle = paymentTitle;
            PaymentDate = paymentDate;
            PublicBiddingGuid = publicBiddingGuid;
            PaymentWarrantGuid = paymentWarrantGuid;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(AccountNumber))
            {
                results.Add(new ValidationResult("AccountNumber cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(ReferenceNumber))
            {
                results.Add(new ValidationResult("ReferenceNumber cannot be empty."));
            }

            if (TotalAmount <= 0)
            {
                results.Add(new ValidationResult("TotalAmount must be greater than 0."));
            }

            if (PayerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PayerGuid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(PaymentTitle))
            {
                results.Add(new ValidationResult("PaymentTitle cannot be empty."));
            }

            if (PaymentDate < DateTime.Now)
            {
                results.Add(new ValidationResult("Payment date cannot be in the past."));
            }

            if (PublicBiddingGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PublicBiddingGuid cannot be empty."));
            }

            if (PaymentWarrantGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PaymentWarrantGuid cannot be empty."));
            }

            return results;
        }
    }
    
}