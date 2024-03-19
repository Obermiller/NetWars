using System.IdentityModel.Tokens.Jwt;
using NetWars.Logic.Identity.Contracts;

namespace NetWars.Logic.Identity;

public class TokenLogic : ITokenLogic
{
	public Guid? GetUserId(string? header)
	{
		if (header is not null && header.StartsWith("Bearer "))
		{
			var token = ParseToken(header);
			var claim = token.Claims.First(claim => claim.Type == "userid");

			if (claim is not null)
			{
				return Guid.Parse(claim.Value);
			}
		}
	
		return null;
	}

	private static JwtSecurityToken ParseToken(string header)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenString = header["Bearer ".Length..];
		var token = tokenHandler.ReadJwtToken(tokenString);

		return token;
	}
}