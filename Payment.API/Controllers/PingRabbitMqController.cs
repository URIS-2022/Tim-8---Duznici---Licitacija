using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Payment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingRabbitMqController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PingRabbitMqController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CheckConnection()
        {
            try
            {
                MQConnection mqc = new(_configuration);
                mqc.Open("Payment.API");
                return Ok("RabbitMQ connection is working");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error connecting to RabbitMQ: " + ex.Message);
            }
        }
    }
}
