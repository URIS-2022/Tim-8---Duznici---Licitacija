using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Payment;

/// <summary>
/// API controller for managing Payment Warrants.
/// </summary>
[ApiExplorerSettings(GroupName = "Payment")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PaymentWarrantsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the PaymentsController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PaymentWarrantsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PAYMENT")}/api/PaymentWarrants");
    }

    /// <summary>
    /// Gets all Payment Warrants.
    /// </summary>
    /// <returns> A list of all Payment Warrants.</returns>
    /// <response code="200">Returns a list of all Payment Warrants</response>
    [HttpGet]
    public Task<IActionResult> GetAllPaymentWarrants()
    => serviceProxy.Get();

    /// <summary>
    /// Gets a Payment warrant by its reference number.
    /// </summary>
    /// <param name="referenceNumber"> The reference number of the payment warrant to get.</param>
    /// <returns> A payment warrant with the specified reference number.</returns>
    /// <response code="200">Returns a payment warrant with the specified reference number</response>
    [HttpGet("reference/{referenceNumber}")]
    public Task<IActionResult> GetByReferenceNumber(string referenceNumber)
        => serviceProxy.GetById($"reference/{referenceNumber}");

    /// <summary>
    /// Gets a Payment warrant by its ID.
    /// </summary>
    /// <param name="id"> The ID of the payment warrant to get.</param>
    /// <returns> A payment warrant with the specified ID.</returns>
    /// <response code="200">Returns a payment warrant with the specified ID</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetPaymentWarrantByGuid(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates a Payment warrant object with the specified reference number.
    /// </summary>
    /// <param name="referenceNumber"> The reference number of the payment warrant object to update.</param>
    /// <param name="requestModel"> The updated payment warrant object.</param>
    /// <returns> The updated payment warrant object.</returns>
    /// <response code="204"> NoContent if the Payment warrant is successfully updated.</response>
    [HttpPatch("{referenceNumber}")]
    [Authorize(Roles = "Superuser,BiddingOperator")]
    public Task<IActionResult> UpdatePaymentWarrant(string referenceNumber, object requestModel)
        => serviceProxy.Patch(referenceNumber, requestModel);

    /// <summary>
    /// Adds a new Payment warrant.
    /// </summary>
    /// <param name="requestModel"> The Payment warrant to add.</param>
    /// <returns> The newly created Payment warrant.</returns>
    /// <response code="201">Returns the newly created Payment warrant</response>
    [HttpPost]
    [Authorize(Roles = "Superuser,BiddingOperator")]
    public Task<IActionResult> AddPaymentWarrant(object requestModel)
        => serviceProxy.Post(requestModel);


    /// <summary>
    /// Deletes a Payment warrant object with the specified reference number.
    /// </summary>
    /// <param name="referenceNumber"> The reference number of the payment warrant object to delete.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the Payment warrant is successfully deleted</response>
    /// <response code="404">If the Payment warrant is not found</response>
    [HttpDelete("reference/{referenceNumber}")]
    [Authorize(Roles = "Superuser,BiddingOperator")]
    public Task<IActionResult> DeletePaymentWarrantByReferenceNumber(string referenceNumber)
        => serviceProxy.Delete($"reference/{referenceNumber}");

    /// <summary>
    /// Deletes a Payment warrant object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the payment warrant object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the Payment warrant is successfully deleted</response>
    /// <response code="404">If the Payment warrant is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator")]
    public Task<IActionResult> DeletePaymentWarrant(string id)
        => serviceProxy.Delete(id);
}
