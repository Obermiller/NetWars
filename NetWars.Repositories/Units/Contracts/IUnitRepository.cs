using NetWars.Core.Models.Schema.Units;

namespace NetWars.Repositories.Units.Contracts;

public interface IUnitRepository
{
	Task<IEnumerable<Unit>> GetAll();
}