
using Payment.API.Models.PaymentWarrantModel;
using System.Text;
using System.Text.Json;

namespace Payment.API.RabbitMQ;
class Requester
{
    public async Task PostNewPaymentWarrant(PaymentWarrantRequestModel paymentWarrant)
    {


        // Serialize the LeaseAgreement object to a JSON string
        var json = JsonSerializer.Serialize(paymentWarrant);

        // Create a new HttpClient instance
        using (var httpClient = new HttpClient())
        {
            // Set the base URL for the API endpoint
            httpClient.BaseAddress = new Uri("https://localhost:7080/api/PaymentWarrants");

            // Create a new HttpRequestMessage with the JSON payload
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7080/api/PaymentWarrants")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Send the POST request
            var response = await httpClient.SendAsync(httpRequestMessage);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Payment Warrant was successfully created.");
            }
            else
            {
                Console.WriteLine("Error creating Payment Warrant. StatusCode: {0}", response.StatusCode);
            }
        }
    }
}