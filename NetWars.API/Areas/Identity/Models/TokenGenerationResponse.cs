namespace NetWars.API.Areas.Identity.Models;

public class TokenGenerationResponse
{
	public TokenGenerationResponse() { }

	public TokenGenerationResponse(string? token)
	{
		Token = token;
	}

	public string? Token { get; set; }
}