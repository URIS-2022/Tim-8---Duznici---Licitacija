using Payment.API.Entities;

namespace Payment.API.Data.Repository;

public interface IPaymentRepository
{
    Task<IEnumerable<PaymentEntity>> GetAllPayments();
    Task<PaymentEntity?> GetPaymentByGuid(Guid guid);
    Task<PaymentEntity?> AddPayment(PaymentEntity paymentEntity);
    Task<PaymentEntity?> UpdatePayment(PaymentEntity paymentEntity);
    Task DeletePayment(Guid guid);

    //Task DeletePaymentByReferenceNumber(string referenceNumber);
    //Task<PaymentEntity?> GetByReferenceNumber(string referenceNumber);
}
