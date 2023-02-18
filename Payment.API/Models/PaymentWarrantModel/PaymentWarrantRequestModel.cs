namespace Payment.API.Models.PaymentWarrantModel;

/// <summary>
/// Represents a payment warrant request model.
/// </summary>
public class PaymentWarrantRequestModel
{
    /// <summary>
    /// Gets or sets the reference number for the payment warrant.
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the payer GUID for the payment warrant.
    /// </summary>
    public Guid PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the payment warrant.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the public bidding GUID for the payment warrant.
    /// </summary>
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentWarrantRequestModel"/> class with the specified values.
    /// </summary>
    /// <param name="referenceNumber">The reference number for the payment warrant.</param>
    /// <param name="payerGuid">The payer GUID for the payment warrant.</param>
    /// <param name="totalAmount">The total amount for the payment warrant.</param>
    /// <param name="publicBiddingGuid">The public bidding GUID for the payment warrant.</param>
    public PaymentWarrantRequestModel(string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
    {
        ReferenceNumber = referenceNumber;
        PayerGuid = payerGuid;
        TotalAmount = totalAmount;
        PublicBiddingGuid = publicBiddingGuid;
    }
}

