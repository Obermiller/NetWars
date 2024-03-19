using Microsoft.AspNetCore.Mvc;

namespace NetWars.API.Areas.Errors;

[ApiController]
[Route("[controller]")]
public class ErrorController(ILogger<ErrorController> logger) : ControllerBase
{
	private readonly ILogger<ErrorController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public ActionResult<string> Index()
	{
		_logger.LogError("An error occurred"); //TODO
		
		return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
	}
}