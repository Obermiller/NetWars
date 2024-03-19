using Microsoft.Extensions.Configuration;
using NetWars.Logic.Url.Contracts;

namespace NetWars.Logic.Url;

public class UrlLogic(IConfiguration config) : IUrlLogic
{
	public string GetBaseUrl() => config["BaseUrl"] ?? string.Empty;
}