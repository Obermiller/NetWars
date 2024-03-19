using NetWars.Core.Models.API.Units;

namespace NetWars.Logic.Units.Contracts;

public interface IUnitLogic
{
	Task<List<UnitResponse>> GetAll(bool includeSubobjects);
}