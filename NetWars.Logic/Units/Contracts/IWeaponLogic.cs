using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;

namespace NetWars.Logic.Units.Contracts;

public interface IWeaponLogic
{
	Task<WeaponResponse?> GetById(int id);
	Task<List<WeaponResponse>> GetByIds(IEnumerable<int> ids);
	Task<int> Insert(Weapon weapon);
}