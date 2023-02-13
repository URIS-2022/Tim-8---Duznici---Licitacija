using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Gateway.API.Helpers;

/// <summary>
/// Implementation of the IComplaintRepository
/// interface for managing Complaint entities in the database.
/// </summary>
public class HttpServiceProxy : ControllerBase, IHttpServiceProxy
{
    private readonly HttpClient httpClient;
    private readonly string downstreamServiceUrl;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpServiceProxy"/> class.
    /// </summary>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to make HTTP requests to the downstream service.</param>
    /// <param name="downstreamServiceUrl">The URL of the downstream service to proxy requests to.</param>
    public HttpServiceProxy(HttpClient httpClient, string downstreamServiceUrl)
    {
        this.httpClient = httpClient;
        this.downstreamServiceUrl = downstreamServiceUrl;
    }

    /// <inheritdoc cref="IHttpServiceProxy.Get"/>
    public async Task<IActionResult> Get(string endpoint = "", string? acceptHeader = "application/json")
        => await SendRequest(HttpMethod.Get, endpoint, null, acceptHeader);

    /// <inheritdoc cref="IHttpServiceProxy.GetById"/>
    public async Task<IActionResult> GetById(string endpoint, string? acceptHeader = "application/json")
        => await SendRequest(HttpMethod.Get, endpoint, null, acceptHeader);

    /// <inheritdoc cref="IHttpServiceProxy.Post"/>
    public async Task<IActionResult> Post(object requestBody, string endpoint = "", string? acceptHeader = "application/json")
        => await SendRequest(HttpMethod.Post, endpoint, requestBody, acceptHeader);

    /// <inheritdoc cref="IHttpServiceProxy.Patch"/>
    public async Task<IActionResult> Patch(string endpoint, object requestBody, string? acceptHeader = "application/json")
        => await SendRequest(HttpMethod.Patch, endpoint, requestBody, acceptHeader);

    /// <inheritdoc cref="IHttpServiceProxy.Delete"/>
    public async Task<IActionResult> Delete(string endpoint, string? acceptHeader = null)
        => await SendRequest(HttpMethod.Delete, endpoint, null, acceptHeader);

    /// <inheritdoc cref="IHttpServiceProxy.Put"/>
    public async Task<IActionResult> Put(string endpoint, object requestBody, string? acceptHeader = null)
        => await SendRequest(HttpMethod.Put, endpoint, requestBody, acceptHeader);

    private async Task<IActionResult> SendRequest(HttpMethod method, string endpoint, object? requestBody = null, string? acceptHeader = null)
    {
        var uri = endpoint is not "" ? $"{downstreamServiceUrl}/{endpoint}" : $"{downstreamServiceUrl}";
        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(uri)
        };

        if (requestBody is not null)
        {
            if (acceptHeader != null && acceptHeader.Contains("application/xml"))
            {
                request.Content = new StringContent(ToXmlString(requestBody), Encoding.UTF8, "application/xml");
            }
            else
            {
                request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            }
        }

        var downstreamResponse = await httpClient.SendAsync(request);
        return await FormatResponse(downstreamResponse, acceptHeader);
    }

    private async Task<IActionResult> FormatResponse(HttpResponseMessage response, string? acceptHeader)
    {
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseContent)) return NoContent();
            return acceptHeader == "application/xml"
                ? StatusCode((int)response.StatusCode, Content(responseContent, "application/xml"))
                : StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<object>(responseContent));
        }
        else
        {
            return StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<object>(await response.Content.ReadAsStringAsync()));
        }
    }

    private static string ToXmlString<T>(T obj)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, obj);
        return stringWriter.ToString();
    }

}
