namespace Auth.API.Models;

/// <summary>
/// JwtTokenRequestModel is a model class used to represent a request for a JSON Web Token (JWT).
/// </summary>
public class JwtTokenRequestModel
{
    /// <summary>
    /// Gets or sets the username string.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password string.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Initializes a new instance of the JwtTokenRequestModel class.
    /// </summary>
    /// <param name="username">The username string.</param>
    /// <param name="password">The password string.</param>
    public JwtTokenRequestModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
