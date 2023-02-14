using Microsoft.EntityFrameworkCore;
using Payment.API.Entities;

namespace Payment.API.Data.Repository;

public class PaymentWarrantRepository : IPaymentWarrantRepository
{
    private readonly PaymentDBContext context;

    /// <summary>
    /// Initializes a new instance of the PaymentWarrantRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public PaymentWarrantRepository(PaymentDBContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IPaymentWarrantRepository.GetAllPaymentWarrants"/>
    public async Task<IEnumerable<PaymentWarrant>> GetAllPaymentWarrants()
    {
        return await context.PaymentWarrants.ToListAsync();
    }


    /// <inheritdoc cref="IPaymentWarrantRepository.AddPaymetWarrant"/>
    public async Task<PaymentWarrant> AddPaymentWarrant(PaymentWarrant paymentWarrant)
    {
        context.PaymentWarrants.Add(paymentWarrant);
        await context.SaveChangesAsync();
        return paymentWarrant;
    }

    /// <inheritdoc cref="IPaymentWarrantRepository.DeletePaymentWarrant"/>
    public async Task DeletePaymentWarrant(Guid guid)
    {
        var paymentWarrant = await context.PaymentWarrants.SingleOrDefaultAsync(x => x.Guid == guid);
        if (paymentWarrant == null)
        {
            throw new InvalidOperationException("PaymentWarrant not found");
        }
        context.PaymentWarrants.Remove(paymentWarrant);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="IPaymentWarrantRepository.DeletePaymentWarrantByReferenceNumber(string)"/>
    public async Task DeletePaymentWarrantByReferenceNumber(string referenceNumber)
    {
        var paymentWarrant = await context.PaymentWarrants.FirstOrDefaultAsync(x => x.ReferenceNumber == referenceNumber);
        if (paymentWarrant == null)
        {
            throw new InvalidOperationException("PaymentWarrant not found");
        }
        context.PaymentWarrants.Remove(paymentWarrant);
        await context.SaveChangesAsync();
    }


    /// <inheritdoc cref="IPaymentWarrantRepository.GetPaymentWarrantByGuid(Guid)"/>
    public async Task<PaymentWarrant?> GetPaymentWarrantByGuid(Guid guid)
    {
        var paymentWarrant = await context.PaymentWarrants.SingleOrDefaultAsync(x => x.Guid == guid);

        return paymentWarrant;
    }

    /// <inheritdoc cref="IPaymentWarrantRepository.GetByReferenceNumber(string)"/>
    public async Task<PaymentWarrant?> GetByReferenceNumber(string referenceNumber)
    {
        PaymentWarrant? paymentWarrant = await context.PaymentWarrants.SingleOrDefaultAsync(x => x.ReferenceNumber == referenceNumber);

        return paymentWarrant;
    }

    /// <inheritdoc cref="IPaymentWarrantRepository.UpdatePaymentWarrant(PaymentWarrant)"/>
    public async Task<PaymentWarrant?> UpdatePaymentWarrant(PaymentWarrant paymentWarrant)
    {
        var existingPaymentWarrant = await context.PaymentWarrants.FirstOrDefaultAsync(c => c.Guid== paymentWarrant.Guid);
        if (existingPaymentWarrant == null)
        {
            throw new InvalidOperationException($"The PaymentWarrant with ID '{paymentWarrant.Guid}' was not found.");
        }

        context.Entry(existingPaymentWarrant).CurrentValues.SetValues(paymentWarrant);
        await context.SaveChangesAsync();

        return existingPaymentWarrant;
    }
}
