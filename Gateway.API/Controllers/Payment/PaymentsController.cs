using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Payment;

/// <summary>
/// API controller for managing Payments.
/// </summary>
[ApiExplorerSettings(GroupName = "Payment")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PaymentsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the PaymentsController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PaymentsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PAYMENT")}/api/Payment");
    }

    /// <summary>
    /// Gets all payments.
    /// </summary>
    /// <returns> A list of all payments.</returns>
    /// <response code="200">Returns a list of all payments</response>
    [HttpGet]
    public Task<IActionResult> GetAllPayments()
        => serviceProxy.Get();

    /// <summary>
    /// Gets a payment by its ID.
    /// </summary>
    /// <param name="id"> The ID of the payment to get.</param>
    /// <returns> A payment with the specified ID.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetPaymentByGuid(string id)
        => serviceProxy.GetById(id);


    /// <summary>
    /// Adds a new payment.
    /// </summary>
    /// <param name="requestModel"> The payment to add.</param>
    /// <returns> The newly created payment.</returns>
    /// <response code="201">Returns the newly created payment</response>
    [HttpPost]
    public Task<IActionResult> AddPayment(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a Payment object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the payment object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the Payment is successfully deleted</response>
    /// <response code="404">If the payment is not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeletePayment(string id)
        => serviceProxy.Delete(id);

    /// <summary>
    /// Updates the payment with the specified id.
    /// </summary>
    /// <param name="id"> The ID of the payment to update.</param>
    /// <param name="requestModel"> The payment to update.</param>
    /// <returns> The updated payment.</returns>
    /// <response code="204"> NoContent if the payment is successfully updated.</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchPayment(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);
}
