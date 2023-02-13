using Payment.API.Entities;

namespace Payment.API.Data.Repository;

public interface IPaymentWarrantRepository
{
    /// <summary>
    /// Gets all PaymentWarrants from the database.
    /// </summary>
    /// <returns>An asynchronous task that returns an enumerable of SystemUser entities.</returns>
    Task<IEnumerable<PaymentWarrant>> GetAllPaymentWarrants();

    /// <summary>
    /// Gets a PaymentWarrant by its Guid identifier.
    /// </summary>
    /// <param name="guid">The Guid identifier of the PaymentWarrant.</param>
    /// <returns>An asynchronous task that returns the PaymentWarrant entity with the specified Guid identifier, or null if no such entity exists.</returns>
    Task<PaymentWarrant?> GetPaymentWarrantByGuid(Guid guid);

    /// <summary>
    /// Gets a PaymantWarrant by its referenceNumber.
    /// </summary>
    /// <param name="referenceNumber">The referenceNumber of the PaymantWarrant.</param>
    /// <returns>An asynchronous task that returns the PaymantWarrant entity with the specified referenceNumber, or null if no such entity exists.</returns>
    Task<PaymentWarrant?> GetByReferenceNumber(string referenceNumber);

    /// <summary>
    /// Adds a new PaymentWarrant to the database.
    /// </summary>
    /// <param name="paymentWarrant">The PaymentWarrant entity to add to the database.</param>
    /// <returns>An asynchronous task that returns the added PaymantWarrant entity.</returns>
    Task<PaymentWarrant?> AddPaymentWarrant(PaymentWarrant paymentWarrant);

    /// <summary>
    /// Updates an existing PaymentWarrant in the database.
    /// </summary>
    /// <param name="paymentWarrant">The PaymentWarrant entity to update in the database.</param>
    /// <returns>An asynchronous task that returns the updated PaymntWarrant entity.</returns>
    Task<PaymentWarrant?> UpdatePaymentWarrant(PaymentWarrant paymentWarrant);

    /// <summary>
    /// Deletes a PaymentWarrant from the database by its Guid identifier.
    /// </summary>
    /// <param name="guid">The Guid identifier of the PaymentWarrant to delete.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task DeletePaymentWarrant(Guid guid);

    /// <summary>
    /// Deletes a PaymentWarrant from the database by its username.
    /// </summary>
    /// <param name="referenceNumber">The referenceNumber of the PaymentWarrant to delete.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task DeletePaymentWarrantByReferenceNumber(string referenceNumber);
}
