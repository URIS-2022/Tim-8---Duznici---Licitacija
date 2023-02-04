namespace Auth.API.Models;

public class JwtTokenRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public JwtTokenRequestModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
