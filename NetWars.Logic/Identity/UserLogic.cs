using NetWars.Repositories.Identity.Contracts;
using NetWars.Repositories.Identity.Models;
using NetWars.Logic.Identity.Contracts;

namespace NetWars.Logic.Identity;

public class UserLogic(IUserRepository userRepo) : IUserLogic
{
	public User GetByEmail(string email) => userRepo.GetByEmail(email);
}