using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.API.Data;
using Payment.API.Data.Repository;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class PaymentWarrantsController : ControllerBase
    {
        private readonly IPaymentWarrantRepository _paymentWarrantRepository;
        private readonly IMapper mapper;

        public PaymentWarrantsController(IPaymentWarrantRepository paymentWarrantRepository, IMapper mapper)
        {
            _paymentWarrantRepository = paymentWarrantRepository;
            this.mapper = mapper;
        }

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

        /*//GET: api/PaymentWarrants/referenceNumber
        [HttpGet("{referenceNumber}")]
        public async Task<ActionResult<PaymentWarrantResponseModel>> GetByReferenceNumber(string referenceNumber)
        {
            PaymentWarrant? paymentWarrant = await _paymentWarrantRepository.GetByReferenceNumber(referenceNumber);
            if (paymentWarrant == null)
            {
                return NotFound();
            }
            PaymentWarrantResponseModel responseModel = mapper.Map<PaymentWarrantResponseModel>(paymentWarrant);
            return Ok(responseModel);
        }*/

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


        // DELETE: api/PaymentWarrants/referenceNumber
        [HttpDelete("{referenceNumber}")]
        public async Task<IActionResult> DeletePaymentWarrantByReferenceNumber(string referenceNumber)
        {
            PaymentWarrant? paymentWarrant = await _paymentWarrantRepository.GetByReferenceNumber(referenceNumber);
            if (paymentWarrant == null)
            {
                return NotFound();
            }
            await _paymentWarrantRepository.DeletePaymentWarrant(paymentWarrant.Guid);

            return NoContent();
        }


        /*private bool PaymentWarrantExists(string id)
        {
            return (_context.PaymentWarrants?.Any(e => e.ReferenceNumber == id)).GetValueOrDefault();
        }*/
    }
}
