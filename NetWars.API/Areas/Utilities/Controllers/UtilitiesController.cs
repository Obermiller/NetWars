using Microsoft.AspNetCore.Mvc;
using NetWars.Core.Constants.Identity;
using NetWars.Logic.Identity.Contracts;
using NetWars.Logic.Url.Contracts;

namespace NetWars.API.Areas.Utilities.Controllers;

public class UtilitiesController(ITokenLogic tokenLogic, IUrlLogic urlLogic) : ControllerBase
{
	//Site
	protected string GetBaseUrl() => urlLogic.GetBaseUrl();

	//Token
	protected Guid? GetUserId()
	{
		return tokenLogic.GetUserId(Request.Headers[IdentityConstants.Authorization]);
	}
}