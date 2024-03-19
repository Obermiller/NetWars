using DapperExtensions;
using Microsoft.Extensions.Configuration;
using NetWars.Repositories.Identity.Contracts;
using NetWars.Repositories.Identity.Models;

namespace NetWars.Repositories.Identity;

public class UserRepository(IConfiguration config) : SqlConnection(config), IUserRepository
{
	public User GetByEmail(string email)
	{
		using var conn = CreateConnection();

		var user = conn.Get<User>(new { Email = email });

		return user;
	}
}