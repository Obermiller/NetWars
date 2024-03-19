using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetWars.API.Areas.Utilities.Controllers;
using NetWars.Core.Models.API.Units;
using NetWars.Logic.Identity.Contracts;
using NetWars.Logic.Units.Contracts;
using NetWars.Logic.Url.Contracts;

namespace NetWars.API.Areas.Units.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]s")]
[Route("api/[controller]s")]
[ApiVersion(1)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Produces("application/json")]
public class UnitController : UtilitiesController
{
	private readonly IUnitLogic _unitLogic;

	private readonly string _baseRoute;
	
	public UnitController(IUnitLogic unitLogic, ITokenLogic tokenLogic, IUrlLogic urlLogic)
		: base(tokenLogic, urlLogic)
	{
		_unitLogic = unitLogic;
		_baseRoute = GetBaseUrl() + "/api/v1.0/Units/";
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UnitResponse>))]
	public async Task<ActionResult<List<UnitResponse>>> Index(bool includeSubobjects = true)
	{
		if (GetUserId() is null)
		{
			return Unauthorized();
		}

		var response = await _unitLogic.GetAll(includeSubobjects);

		return Ok(response);
	}
}