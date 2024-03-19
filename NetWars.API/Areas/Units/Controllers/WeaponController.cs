using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetWars.API.Areas.Utilities.Controllers;
using NetWars.API.Models;
using NetWars.Core.Models.Schema.Units;
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
public class WeaponController : UtilitiesController
{
	private readonly IWeaponLogic _weaponLogic;
	
	private readonly string _baseRoute;

	public WeaponController(IWeaponLogic weaponLogic, ITokenLogic tokenLogic, IUrlLogic urlLogic)
		: base(tokenLogic, urlLogic)
	{
		_weaponLogic = weaponLogic;
		_baseRoute = $"{GetBaseUrl()}/api/v1/Weapons";
	}
	
	//TODO - how do we want to get Targets in?
	[HttpPost, Route(nameof(Create))]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<PostResult>> Create([FromBody] Weapon request)
	{
		var id = await _weaponLogic.Insert(request);

		var route = _baseRoute + id;
		
		return Created(route, new PostResult { Created = id });
	}
	
	[HttpGet("{id:int}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Weapon>> GetById(int id)
	{
		var weapon = await _weaponLogic.GetById(id);
		if (weapon is null)
		{
			return NotFound();
		}
		
		return weapon;
	}
}