namespace Auth.API.Models;

/// <summary>
/// IntrospectionRequestModel is a model class used to represent a request for introspection of a JSON Web Token (JWT).
/// </summary>
public class IntrospectionRequestModel
{
    /// <summary>
    /// Gets or sets the token string.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Initializes a new instance of the IntrospectionRequestModel class.
    /// </summary>
    /// <param name="token">The token string.</param>
    public IntrospectionRequestModel(string token)
    {
        Token = token;
    }
}
