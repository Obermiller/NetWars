using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetWars.API.Areas.Identity.Models;
using NetWars.Logic.Identity.Contracts;

namespace NetWars.API.Areas.Identity.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v{version:apiVersion}")]
[ApiVersion("1.0")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[Produces("application/json")]
public class IdentityController(IConfiguration configuration, IUserLogic userLogic) : ControllerBase
{
	[HttpPost("Token")]
	public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!);

		if (userLogic.GetByEmail(request.Email) is not { } user)
		{
			return BadRequest($"User with email {request.Email} not found.");
		}
		
		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new(JwtRegisteredClaimNames.Sub, user.Email),
			new(JwtRegisteredClaimNames.Email, user.Email),
			new("userid", user.Id.ToString())
		};

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = configuration["JwtSettings:Audience"],
			Issuer = configuration["JwtSettings:Issuer"],
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		var jwt = tokenHandler.WriteToken(token);
		return Ok(jwt);
	}
}