using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

public class HttpServiceProxy : ControllerBase
{
    private readonly HttpClient httpClient;
    private readonly string downstreamServiceUrl;

    public HttpServiceProxy(HttpClient httpClient, string downstreamServiceUrl)
    {
        this.httpClient = httpClient;
        this.downstreamServiceUrl = downstreamServiceUrl;
    }

    public async Task<IActionResult> Get(string endpoint = "", string? acceptHeader = null)
    {
        var uri = endpoint is not "" ? $"{downstreamServiceUrl}/{endpoint}" : $"{downstreamServiceUrl}";
        var downstreamResponse = await httpClient.GetAsync(uri);

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    public async Task<IActionResult> GetById(string endpoint, string? acceptHeader = null)
    {
        var downstreamResponse = await httpClient.GetAsync($"{downstreamServiceUrl}/{endpoint}");

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    public async Task<IActionResult> Post(object requestBody, string endpoint = "", string? acceptHeader = null)
    {
        var uri = endpoint is not "" ? $"{downstreamServiceUrl}/{endpoint}" : $"{downstreamServiceUrl}";
        var downstreamResponse = await httpClient.PostAsync($"{uri}", JsonContent.Create(requestBody));

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    public async Task<IActionResult> Patch(string endpoint, object requestBody, string? acceptHeader = null)
    {
        var uri = endpoint is not "" ? $"{downstreamServiceUrl}/{endpoint}" : $"{downstreamServiceUrl}";
        var request = new HttpRequestMessage
        {
            Method = new HttpMethod("PATCH"),
            RequestUri = new Uri(uri),
            Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
        };

        var downstreamResponse = await httpClient.SendAsync(request);

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    public async Task<IActionResult> Delete(string endpoint, string? acceptHeader = null)
    {
        var downstreamResponse = await httpClient.DeleteAsync($"{downstreamServiceUrl}/{endpoint}");

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    public async Task<IActionResult> Put(string endpoint, object requestBody, string? acceptHeader = null)
    {
        var requestJson = JsonSerializer.Serialize(requestBody);
        var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var downstreamResponse = await httpClient.PutAsync($"{downstreamServiceUrl}/{endpoint}", requestContent);

        return await FormatRespose(downstreamResponse, acceptHeader);
    }

    private static string ConvertJsonToXml(string json)
    {
        var jsonObject = JsonSerializer.Deserialize<JsonElement>(json);
        var sb = new StringBuilder();
        using (var writer = new StringWriter(sb))
        {
            var serializer = new XmlSerializer(jsonObject.GetType());
            serializer.Serialize(writer, jsonObject);
        }
        return sb.ToString();
    }

    private async Task<IActionResult> FormatRespose(HttpResponseMessage respose, string? acceptHeader)
    {
        if (respose.IsSuccessStatusCode)
        {
            var responseContent = await respose.Content.ReadAsStringAsync();
            if (responseContent.IsNullOrEmpty()) return NoContent();
            return acceptHeader == "application/xml"
                ? Content(ConvertJsonToXml(responseContent), "application/xml")
                : StatusCode((int)respose.StatusCode, JsonSerializer.Deserialize<object>(responseContent));
        }
        else
        {
            return StatusCode((int)respose.StatusCode, JsonSerializer.Deserialize<object>(await respose.Content.ReadAsStringAsync()));
        }
    }
}
