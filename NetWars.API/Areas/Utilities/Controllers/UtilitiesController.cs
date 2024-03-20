using Microsoft.AspNetCore.Mvc;
using NetWars.Core.Constants.Identity;
using NetWars.Logic.Identity.Contracts;
using NetWars.Logic.Url.Contracts;

namespace NetWars.API.Areas.Utilities.Controllers;

public class UtilitiesController(ITokenLogic tokenLogic, IUrlLogic urlLogic) : ControllerBase
{
	#region Site

	protected string GetBaseUrl() => urlLogic.GetBaseUrl();

	#endregion

	#region Token

	protected Guid? GetUserId() => tokenLogic.GetUserId(Request.Headers[IdentityConstants.Authorization]);

	#endregion
}