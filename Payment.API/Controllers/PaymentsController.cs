using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Data.Repository;
using Payment.API.Models.PaymentModel;
using Payment.API.Models.PaymentModels;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper mapper;

        public PaymentsController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

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


        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PaymentResponseModel>> AddPayment(PaymentRequestModel requestModel)
        {
            var requestedPayment = mapper.Map<Entities.Payment>(requestModel);
            Entities.Payment? createdPayment = await _paymentRepository.AddPayment((Entities.Payment)requestedPayment);
            if (createdPayment == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<PaymentResponseModel>(createdPayment);
            return CreatedAtAction("GetPaymentByGuid", new { id = createdPayment.Guid }, responseModel);
        }


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

        /*private bool PaymentEntityExists(Guid id)
        {
            return (_context.Payments?.Any(e => e.Guid == id)).GetValueOrDefault();
        */
    }
}
