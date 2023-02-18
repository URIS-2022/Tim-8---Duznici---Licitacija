using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Data.Repository;
using Payment.API.Models.PaymentModel;
using Payment.API.Models.PaymentModels;


namespace Payment.API.Controllers
{
    /// <summary>
    /// Controller class for managing payments in the Payment API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the PaymentsController class with the specified dependencies.
        /// </summary>
        /// <param name="paymentRepository">An object that implements the IPaymentRepository interface for accessing payment data.</param>
        /// <param name="mapper">An IMapper object used to map between domain model objects and response/request model objects.</param>
        public PaymentsController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all payments from the payment repository.
        /// </summary>
        /// <returns>A list of PaymentResponseModel objects representing the payments.</returns>
        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentResponseModel>>> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPayments();
            if (!payments.Any())
            {
                return NoContent();
            }
            var responseModel = mapper.Map<IEnumerable<PaymentResponseModel>>(payments);
            return Ok(responseModel);
        }
        /// <summary>
        /// Retrieves a single payment with the specified ID from the payment repository.
        /// </summary>
        /// <param name="id">The ID of the payment to retrieve.</param>
        /// <returns>A PaymentResponseModel object representing the payment, or a NotFoundResult if no payment with the specified ID was found.</returns>
        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResponseModel>> GetPaymentByGuid(Guid id)
        {
            var payment = await _paymentRepository.GetPaymentByGuid(id);
            if (payment == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<PaymentResponseModel>(payment);
            return responseModel;
        }

        /// <summary>
        /// Adds a new payment to the payment repository.
        /// </summary>
        /// <param name="requestModel">A PaymentRequestModel object representing the payment to add.</param>
        /// <returns>A CreatedAtActionResult object representing the newly created payment, or a BadRequestResult if the request model was invalid.</returns>
        [HttpPost]
        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PaymentResponseModel>> AddPayment(PaymentRequestModel requestModel)
        {
            var requestedPayment = mapper.Map<Entities.Payment>(requestModel);
            Entities.Payment? createdPayment = await _paymentRepository.AddPayment(requestedPayment);
            if (createdPayment == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<PaymentResponseModel>(createdPayment);
            return CreatedAtAction("GetPaymentByGuid", new { id = createdPayment.Guid }, responseModel);
        }

        /// <summary>
        /// Deletes a payment with the specified ID from the payment repository.
        /// </summary>
        /// <param name="id">The ID of the payment to delete.</param>
        /// <returns>A NoContentResult indicating that the payment was successfully deleted, or a NotFoundResult if no payment with the specified ID was found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            Entities.Payment? payment = await _paymentRepository.GetPaymentByGuid(id);
            if (payment == null)
            {
                return NotFound();
            }
            await _paymentRepository.DeletePayment(payment.Guid);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing payment with the specified ID in the payment repository.
        /// </summary>
        /// <param name="id">The ID of the payment to update.</param>
        /// <param name="paymentUpdateModel">A PaymentUpdateModel object representing the updated payment information.</param>
        /// <returns>A NoContentResult indicating that the payment was successfully updated, or a BadRequestResult if the payment with the specified ID was not found or the payment update model was invalid.</returns>

        [HttpPatch("{id}")]
        public async Task<IActionResult> PutPayment(Guid id, PaymentUpdateModel paymentUpdateModel)
        {
            var payment = await _paymentRepository.GetPaymentByGuid(id);
            if (payment == null || paymentUpdateModel == null)
            {
                return BadRequest();
            }
            mapper.Map(paymentUpdateModel, payment);

            await _paymentRepository.UpdatePayment(payment);
            return NoContent();
        }
    }
}
