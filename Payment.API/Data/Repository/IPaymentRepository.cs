namespace Payment.API.Data.Repository;

///<summary>
/// Represents a repository for managing Payment entities.
///</summary>
public interface IPaymentRepository
{
    ///<summary>
    /// Returns all Payment entities.
    ///</summary>
    Task<IEnumerable<Entities.Payment>> GetAllPayments();

    ///<summary>
    /// Returns a Payment entity by its unique identifier.
    ///</summary>
    ///<param name="guid">The unique identifier of the Payment entity to retrieve.</param>
    ///<returns>The Payment entity with the specified unique identifier, or null if not found.</returns>
    Task<Entities.Payment?> GetPaymentByGuid(Guid guid);
    ///<summary>
    /// Adds a new Payment entity.
    ///</summary>
    ///<param name="paymentEntity">The Payment entity to add.</param>
    ///<returns>The added Payment entity, or null if it could not be added.</returns>
    Task<Entities.Payment?> AddPayment(Entities.Payment paymentEntity);
    ///<summary>
    /// Updates an existing Payment entity.
    ///</summary>
    ///<param name="paymentEntity">The Payment entity to update.</param>
    ///<returns>The updated Payment entity, or null if it could not be updated.</returns>
    Task<Entities.Payment?> UpdatePayment(Entities.Payment paymentEntity);
    ///<summary>
    /// Deletes a Payment entity by its unique identifier.
    ///</summary>
    ///<param name="guid">The unique identifier of the Payment entity to delete.</param>
    Task DeletePayment(Guid guid);

}
