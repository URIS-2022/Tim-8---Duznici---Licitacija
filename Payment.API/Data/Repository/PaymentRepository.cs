using Microsoft.EntityFrameworkCore;

namespace Payment.API.Data.Repository;

/// <summary>
/// Repository class for Payment entity. Implements <see cref="IPaymentRepository"/>.
/// </summary>
public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDBContext context;
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentRepository"/> class.
    /// </summary>
    /// <param name="context">The PaymentDBContext object.</param>
    public PaymentRepository(PaymentDBContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IPaymentRepository.GetAllPayments"/>
    public async Task<IEnumerable<Entities.Payment>> GetAllPayments()
    {
        return await context.Payments.Include(p => p.PaymentWarrant).ToListAsync();
    }
    /// <inheritdoc cref="IPaymentRepository.GetPaymentByGuid"/>
    public async Task<Entities.Payment> GetPaymentByGuid(Guid guid)
    {
        return await context.Payments.Include(p => p.PaymentWarrant).FirstOrDefaultAsync(p => p.Guid == guid);
    }

    /// <inheritdoc cref="IPaymentRepository.AddPayment"/>
    public async Task<Entities.Payment> AddPayment(Entities.Payment paymentEntity)
    {
        var created = context.Payments.Add(paymentEntity);
        await context.SaveChangesAsync();
        return created.Entity;
    }
    /// <inheritdoc cref="IPaymentRepository.DeletePayment"/>
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
    /// <inheritdoc cref="IPaymentRepository.UpdatePayment"/>
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
}
