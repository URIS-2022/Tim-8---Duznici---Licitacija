namespace Payment.API.Models.PaymentModel;

/// <summary>
/// Represents a payment request model.
/// </summary>
public class PaymentRequestModel
{
    /// <summary>
    /// Gets or sets the account number for the payment request.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the reference number for the payment request.
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the payment request.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the payer GUID for the payment request.
    /// </summary>
    public Guid PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the payment title for the payment request.
    /// </summary>
    public string PaymentTitle { get; set; }

    /// <summary>
    /// Gets or sets the payment date for the payment request.
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Gets or sets the public bidding GUID for the payment request.
    /// </summary>
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentRequestModel"/> class.
    /// </summary>
    /// <param name="accountNumber">The account number for the payment request.</param>
    /// <param name="referenceNumber">The reference number for the payment request.</param>
    /// <param name="totalAmount">The total amount for the payment request.</param>
    /// <param name="payerGuid">The payer GUID for the payment request.</param>
    /// <param name="paymentTitle">The payment title for the payment request.</param>
    /// <param name="paymentDate">The payment date for the payment request.</param>
    /// <param name="publicBiddingGuid">The public bidding GUID for the payment request.</param>
    public PaymentRequestModel(string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid)
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

