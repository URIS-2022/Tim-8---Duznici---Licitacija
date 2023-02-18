using System.Runtime.Serialization;

/// <summary>
/// Represents a payment warrant payment response model.
/// </summary>
[DataContract(Name = "PaymentWarrantPaymentResponseModel", Namespace = "")]
public class PaymentWarrantPaymentResponseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the payment warrant.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the payer associated with the payment warrant.
    /// </summary>
    [DataMember]
    public Guid PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the payment warrant.
    /// </summary>
    [DataMember]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the public bidding associated with the payment warrant.
    /// </summary>
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }
}
