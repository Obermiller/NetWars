using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetWars.API.Areas.Utilities.Controllers;
using NetWars.API.Models;
using NetWars.Core.Models.API.Units;
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
	[HttpPost, Route("CreateSingle")]
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
		if (id <= 0)
		{
			return BadRequest();
		}
		
		var weapon = await _weaponLogic.GetById(id);
		if (weapon is null)
		{
			return NotFound();
		}
		
		return weapon;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<List<Weapon>>> Index()
	{
		var weapons = await _weaponLogic.GetAll();
		
		return weapons;
	}
	
	[HttpPut, Route("{id:int}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Weapon))]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<ActionResult<Weapon>> Update(int id, [FromBody] Weapon request)
	{
		if (id <= 0)
		{
			return BadRequest();
		}
		
		try
		{
			var result = await _weaponLogic.Update(id, request);
			
			if (result)
			{
				return Created(_baseRoute + id, new PostResult { Created = id });
			}
		}
		catch (InvalidOperationException)
		{
			return NoContent();
		}
		
		return Conflict();
	}
}