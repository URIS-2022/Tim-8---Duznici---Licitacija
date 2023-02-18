namespace Auth.API.Models;

/// <summary>
/// JwtTokenResponseModel is a model class used to represent a JSON Web Token (JWT) response.
/// </summary>
public class JwtTokenResponseModel
{
    /// <summary>
    /// Gets or sets the token string.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Gets or sets the token type string, which is typically "Bearer".
    /// </summary>
    public string TokenType { get; set; }

    /// <summary>
    /// Gets or sets the number of seconds until the token expires.
    /// </summary>
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the token was issued.
    /// </summary>
    public DateTime IssuedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the JwtTokenResponseModel class.
    /// </summary>
    /// <param name="token">The token string.</param>
    /// <param name="expiresIn">The number of seconds until the token expires.</param>
    /// <param name="issuedAt">The date and time when the token was issued.</param>
    /// <param name="tokenType">The token type string, which is typically "Bearer".</param>
    public JwtTokenResponseModel(string token, int expiresIn, DateTime issuedAt, string tokenType = "Bearer")
    {
        Token = token;
        TokenType = tokenType;
        ExpiresIn = expiresIn;
        IssuedAt = issuedAt;
    }
}
