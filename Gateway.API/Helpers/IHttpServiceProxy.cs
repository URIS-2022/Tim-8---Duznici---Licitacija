using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Helpers;

/// <summary>
/// A interface for proxy service that handles communication between an API and an external HTTP service.
/// </summary>
public interface IHttpServiceProxy
{
    /// <summary>
    /// Sends a GET request to the specified endpoint of the external service.
    /// </summary>
    /// <param name="endpoint">The endpoint of the external service to send the request to. If empty, the base URL of the external service is used.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> Get(string endpoint = "", string acceptHeader = "application/json");

    /// <summary>
    /// Sends a GET request to the specified endpoint of the external service with a unique identifier.
    /// </summary>
    /// <param name="endpoint">The endpoint of the external service to send the request to, including the identifier.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> GetById(string endpoint, string acceptHeader = "application/json");

    /// <summary>
    /// Sends a POST request to the specified endpoint of the external service with the specified request body.
    /// </summary>
    /// <param name="requestBody">The request body to send in the request.</param>
    /// <param name="endpoint">The endpoint of the external service to send the request to. If empty, the base URL of the external service is used.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> Post(object requestBody, string endpoint = "", string acceptHeader = "application/json");

    /// <summary>
    /// Sends a PATCH request to the specified endpoint of the external service with the specified request body.
    /// </summary>
    /// <param name="endpoint">The endpoint of the external service to send the request to. If empty, the base URL of the external service is used.</param>
    /// <param name="requestBody">The request body to send in the request.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> Patch(string endpoint, object requestBody, string acceptHeader = "application/json");

    /// <summary>
    /// Sends a PUT request to the specified endpoint of the external service.
    /// </summary>
    /// <param name="endpoint">The endpoint of the external service to send the request to, including the identifier.</param>
    /// <param name="requestBody">The request body to send in the request.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> Put(string endpoint, object requestBody, string? acceptHeader = null);

    /// <summary>
    /// Sends a DELETE request to the specified endpoint of the external service.
    /// </summary>
    /// <param name="endpoint">The endpoint of the external service to send the request to, including the identifier.</param>
    /// <param name="acceptHeader">The accept header to include in the request. If not provided, the response will be formatted as JSON.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response from the external service.</returns>
    Task<IActionResult> Delete(string endpoint, string? acceptHeader = null);
}
