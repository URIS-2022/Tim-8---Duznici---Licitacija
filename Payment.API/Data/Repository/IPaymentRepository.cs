namespace Payment.API.Data.Repository;

public interface IPaymentRepository
{
    Task<IEnumerable<Entities.Payment>> GetAllPayments();
    Task<Entities.Payment?> GetPaymentByGuid(Guid guid);
    Task<Entities.Payment?> AddPayment(Entities.Payment paymentEntity);
    Task<Entities.Payment?> UpdatePayment(Entities.Payment paymentEntity);
    Task DeletePayment(Guid guid);

    //Task DeletePaymentByReferenceNumber(string referenceNumber);
    //Task<PaymentEntity?> GetByReferenceNumber(string referenceNumber);
}
