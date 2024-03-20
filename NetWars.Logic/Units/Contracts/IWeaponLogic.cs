using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;

namespace NetWars.Logic.Units.Contracts;

public interface IWeaponLogic
{
	Task<List<Weapon>> GetAll();
	Task<Weapon?> GetById(int id);
	Task<List<Weapon>> GetByIds(IEnumerable<int> ids);
	Task<int> Insert(Weapon weapon);
	Task<bool> Update(int id, Weapon weapon);
}