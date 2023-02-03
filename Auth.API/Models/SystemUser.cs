namespace Auth.API.Models;

public class SystemUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}

