using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Data.Repository;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Controllers
{
    /// <summary>
    /// Controller for managing payment warrants.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class PaymentWarrantsController : ControllerBase
    {
        private readonly IPaymentWarrantRepository _paymentWarrantRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the PaymentWarrantsController class with the specified dependencies.
        /// </summary>
        /// <param name="paymentWarrantRepository">An object that implements the IPaymentWarrantRepository interface for accessing payment warrant data.</param>
        /// <param name="mapper">An IMapper object used to map between domain model objects and response/request model objects.</param>
        public PaymentWarrantsController(IPaymentWarrantRepository paymentWarrantRepository, IMapper mapper)
        {
            _paymentWarrantRepository = paymentWarrantRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a collection of all payment warrants.
        /// </summary>
        /// <returns>An ActionResult object containing a collection of PaymentWarrantResponseModel objects, or a 204 No Content response if there are no payment warrants.</returns>
        // GET: api/PaymentWarrants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IPaymentWarrantRepository>>> GetAllPaymentWarrants()
        {
            var paymentWarrants = await _paymentWarrantRepository.GetAllPaymentWarrants();
            if (!paymentWarrants.Any())
            {
                return NoContent();
            }
            IEnumerable<PaymentWarrantResponseModel> responseModels = mapper.Map<IEnumerable<PaymentWarrantResponseModel>>(paymentWarrants);
            return Ok(responseModels);
        }


        /// <summary>
        /// Returns a payment warrant with the specified reference number.
        /// </summary>
        /// <param name="referenceNumber">The reference number of the payment warrant to retrieve.</param>
        /// <returns>An ActionResult object containing a PaymentWarrantResponseModel object if the payment warrant is found, or a 404 Not Found response if it is not found.</returns>
        // GET: api/PaymentWarrants/referenceNumber
        [HttpGet("reference/{referenceNumber}")]
        public async Task<ActionResult<PaymentWarrantResponseModel>> GetByReferenceNumber(string referenceNumber)
        {
            PaymentWarrant? paymentWarrant = await _paymentWarrantRepository.GetByReferenceNumber(referenceNumber);
            if (paymentWarrant == null)
            {
                return NotFound();
            }
            PaymentWarrantResponseModel responseModel = mapper.Map<PaymentWarrantResponseModel>(paymentWarrant);
            return Ok(responseModel);
        }


        /// <summary>
        /// Returns a payment warrant with the specified GUID.
        /// </summary>
        /// <param name="id">The GUID of the payment warrant to retrieve.</param>
        /// <returns>An ActionResult object containing a PaymentWarrantResponseModel object if the payment warrant is found, or a 404 Not Found response if it is not found.</returns>
        // GET: api/PaymentWarrants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentWarrantResponseModel>> GetPaymentWarrantByGuid(Guid id)
        {
            var payment = await _paymentWarrantRepository.GetPaymentWarrantByGuid(id);
            if (payment == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<PaymentWarrantResponseModel>(payment);
            return responseModel;
        }

        /**
        * Updates a payment warrant by reference number.
        * 
        * @param referenceNumber The reference number of the payment warrant to update.
        * @param paymentWarrantUpdateModel The PaymentWarrantUpdateModel representing the updated payment warrant.
        * @return NoContent if successful, BadRequest if the payment warrant or update model is null.
        */
        // PUT: api/PaymentWarrants/referenceNumber
        [HttpPatch("{referenceNumber}")]
        public async Task<IActionResult> UpdatePaymentWarrant(string referenceNumber, PaymentWarrantUpdateModel paymentWarrantUpdateModel)
        {
            var paymentWarrant = await _paymentWarrantRepository.GetByReferenceNumber(referenceNumber);
            if (paymentWarrant == null || paymentWarrantUpdateModel == null)
            {
                return BadRequest();
            }
            mapper.Map(paymentWarrantUpdateModel, paymentWarrant);

            await _paymentWarrantRepository.UpdatePaymentWarrant(paymentWarrant);
            return NoContent();
        }

        /// <summary>
        /// Creates a new payment warrant and adds it to the payment warrants repository.
        /// </summary>
        /// <param name="requestModel">The payment warrant request model containing the payment warrant data.</param>
        /// <returns>An ActionResult of PaymentWarrantResponseModel representing the created payment warrant.</returns>
        // POST: api/PaymentWarrants
        [HttpPost]
        public async Task<ActionResult<PaymentWarrantResponseModel>> AddPaymentWarrant(PaymentWarrantRequestModel requestModel)
        {
            PaymentWarrant requestedPaymentWarrant = mapper.Map<PaymentWarrant>(requestModel);
            PaymentWarrant? createdPaymentWarrant = await _paymentWarrantRepository.AddPaymentWarrant(requestedPaymentWarrant);
            if (createdPaymentWarrant == null)
            {
                return BadRequest();
            }
            PaymentWarrantResponseModel responseModel = mapper.Map<PaymentWarrantResponseModel>(createdPaymentWarrant);
            return CreatedAtAction("GetPaymentWarrantByGuid", new { id = createdPaymentWarrant.Guid }, responseModel);
        }


        /// <summary>
        /// Deletes a payment warrant by its unique identifier.
        /// </summary>
        /// <param name="referenceNumber">The unique identifier of the payment warrant to be deleted.</param>
        /// <returns>A NoContentResult if the payment warrant was successfully deleted, otherwise a NotFoundResult.</returns>
        // DELETE: api/PaymentWarrants/referenceNumber
        [HttpDelete("reference/{referenceNumber}")]
        public async Task<IActionResult> DeletePaymentWarrantByReferenceNumber(string referenceNumber)
        {
            PaymentWarrant? paymentWarrant = await _paymentWarrantRepository.GetByReferenceNumber(referenceNumber);
            if (paymentWarrant == null)
            {
                return NotFound();
            }
            if (paymentWarrant.ReferenceNumber == null)
            {
                return BadRequest();
            }
            await _paymentWarrantRepository.DeletePaymentWarrantByReferenceNumber(paymentWarrant.ReferenceNumber);

            return NoContent();
        }

        /// <summary>
        /// Deletes a payment warrant by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the payment warrant to be deleted.</param>
        /// <returns>A NoContentResult if the payment warrant was successfully deleted, otherwise a NotFoundResult.</returns>
        // DELETE: api/PaymentWarrants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentWarrant(Guid id)
        {
            var paymentWarrant = await _paymentWarrantRepository.GetPaymentWarrantByGuid(id);
            if (paymentWarrant == null)
            {
                return NotFound();
            }
            await _paymentWarrantRepository.DeletePaymentWarrant(paymentWarrant.Guid);

            return NoContent();
        }
    }
}
