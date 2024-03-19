using NetWars.Repositories.Identity.Models;

namespace NetWars.Logic.Identity.Contracts;

public interface IUserLogic
{
	User GetByEmail(string email);
}