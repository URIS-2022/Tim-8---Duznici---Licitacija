using Lease.API.Entities;
using Lease.API.Models.LeaseAgreementModels;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lease.API.Controllers;
 class Requester
{
    public async Task PostNewLeaseAgreement(LeaseAgreementPostRequestModel leaseAgreement)
    {


        // Serialize the LeaseAgreement object to a JSON string
        var json = JsonSerializer.Serialize(leaseAgreement);

        // Create a new HttpClient instance
        using (var httpClient = new HttpClient())
        {
            // Set the base URL for the API endpoint
            httpClient.BaseAddress = new Uri("https://localhost:7060/api/LeaseAgreement");

            // Create a new HttpRequestMessage with the JSON payload
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7060/api/LeaseAgreement")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Send the POST request
            var response = await httpClient.SendAsync(httpRequestMessage);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Lease agreement was successfully created.");
            }
            else
            {
                Console.WriteLine("Error creating lease agreement. StatusCode: {0}", response.StatusCode);
            }
        }
    }
}