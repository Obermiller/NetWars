using NetWars.Repositories.Identity.Models;

namespace NetWars.Repositories.Identity.Contracts;

public interface IUserRepository
{
	User GetByEmail(string email);
}