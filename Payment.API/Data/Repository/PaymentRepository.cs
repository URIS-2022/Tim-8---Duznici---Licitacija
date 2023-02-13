using Microsoft.EntityFrameworkCore;
using Payment.API.Entities;

namespace Payment.API.Data.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDBContext context;

    public PaymentRepository(PaymentDBContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Entities.Payment>> GetAllPayments()
    {
        return await context.Payments.ToListAsync();
    }
    public async Task<Entities.Payment> GetPaymentByGuid(Guid guid)
    {
        return await context.Payments.FindAsync(guid);
    }
    public async Task<Entities.Payment> AddPayment(Entities.Payment paymentEntity)
    {
        context.Payments.Add(paymentEntity);
        await context.SaveChangesAsync();
        return paymentEntity;
    }

    public async Task DeletePayment(Guid guid)
    {
        var paymentEntity = await context.Payments.FindAsync(guid);
        if (paymentEntity == null)
        {
            throw new InvalidOperationException("Payment not found");
        }
        context.Payments.Remove(paymentEntity);
        await context.SaveChangesAsync();
    }

    public async Task<Entities.Payment?> UpdatePayment(Entities.Payment paymentEntity)
    {
        var existingPayment = await context.Payments.FindAsync(paymentEntity.Guid);
        if (existingPayment == null)
        {
            throw new InvalidOperationException($"The Payment with ID '{paymentEntity.Guid}' was not found.");
        }

        context.Entry(existingPayment).CurrentValues.SetValues(paymentEntity);
        await context.SaveChangesAsync();

        return existingPayment;
    }


    /*///<inheritdoc cref="IPaymentRepository.GetByReferenceNumber(string)"/>
    public async Task<PaymentEntity?> GetByReferenceNumber(string referenceNumber)
    {
        PaymentEntity? paymentEntity = await context.Payments.SingleOrDefaultAsync(x => x.ReferenceNumber == referenceNumber);

        return paymentEntity;
    }
    */
}
