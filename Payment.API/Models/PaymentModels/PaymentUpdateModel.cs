namespace Payment.API.Models.PaymentModels;

/// <summary>
/// Represents a model for updating a payment.
/// </summary>
public class PaymentUpdateModel
{
    /// <summary>
    /// Gets or sets the account number associated with the payment.
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the reference number associated with the payment.
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the payment.
    /// </summary>
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the payer's unique identifier associated with the payment.
    /// </summary>
    public Guid? PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the title associated with the payment.
    /// </summary>
    public string? PaymentTitle { get; set; }

    /// <summary>
    /// Gets or sets the payment date associated with the payment.
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// Gets or sets the public bidding's unique identifier associated with the payment.
    /// </summary>
    public Guid? PublicBiddingGuid { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentUpdateModel"/> class with the specified properties.
    /// </summary>
    /// <param name="accountNumber">The account number associated with the payment.</param>
    /// <param name="referenceNumber">The reference number associated with the payment.</param>
    /// <param name="totalAmount">The total amount of the payment.</param>
    /// <param name="payerGuid">The payer's unique identifier associated with the payment.</param>
    /// <param name="paymentTitle">The title associated with the payment.</param>
    /// <param name="paymentDate">The payment date associated with the payment.</param>
    /// <param name="publicBiddingGuid">The public bidding's unique identifier associated with the payment.</param>
    public PaymentUpdateModel(string? accountNumber, string? referenceNumber, decimal? totalAmount, Guid? payerGuid, string? paymentTitle, DateTime? paymentDate, Guid? publicBiddingGuid)
    {
        AccountNumber = accountNumber;
        ReferenceNumber = referenceNumber;
        TotalAmount = totalAmount;
        PayerGuid = payerGuid;
        PaymentTitle = paymentTitle;
        PaymentDate = paymentDate;
        PublicBiddingGuid = publicBiddingGuid;
    }
}

