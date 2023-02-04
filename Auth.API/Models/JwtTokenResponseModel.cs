namespace Auth.API.Models;

public class JwtTokenResponseModel
{
    public string Token { get; set; }

    public string TokenType { get; set; }

    public int ExpiresIn { get; set; }

    public DateTime IssuedAt { get; set; }

    public JwtTokenResponseModel(string token, int expiresIn, DateTime issuedAt, string tokenType = "Bearer")
    {
        Token = token;
        TokenType = tokenType;
        ExpiresIn = expiresIn;
        IssuedAt = issuedAt;
    }
}
