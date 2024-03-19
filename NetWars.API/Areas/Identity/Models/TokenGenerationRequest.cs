namespace NetWars.API.Areas.Identity.Models;

public class TokenGenerationRequest
{
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}