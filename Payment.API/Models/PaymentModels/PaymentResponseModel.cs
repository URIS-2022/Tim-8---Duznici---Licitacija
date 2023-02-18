using Payment.API.Models.PaymentWarrantModel;
using System.Runtime.Serialization;

namespace Payment.API.Models.PaymentModels;

/// <summary>
/// Data contract for a Payment response.
/// </summary>
[DataContract(Name = "Payment", Namespace = "")]
public class PaymentResponseModel
{
    /// <summary>
    /// Gets or sets the GUID of the Payment.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the account number of the Payment.
    /// </summary>
    [DataMember]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the reference number of the Payment.
    /// </summary>
    [DataMember]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the Payment.
    /// </summary>
    [DataMember]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the payer GUID of the Payment.
    /// </summary>
    [DataMember]
    public Guid PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the payment title of the Payment.
    /// </summary>
    [DataMember]
    public string? PaymentTitle { get; set; }

    /// <summary>
    /// Gets or sets the payment date of the Payment.
    /// </summary>
    [DataMember]
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Gets or sets the public bidding GUID of the Payment.
    /// </summary>
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// Gets or sets the PaymentWarrant associated with the Payment.
    /// </summary>
    [DataMember]
    public PaymentWarrantPaymentResponseModel? PaymentWarrant { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentResponseModel"/> class.
    /// </summary>
    // public PaymentResponseModel(/*string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid*/)
    public PaymentResponseModel()
    {
    }
}

