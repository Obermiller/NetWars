using NetWars.Core.Models.Schema.Units;

namespace NetWars.Repositories.Units.Contracts;

public interface IWeaponRepository
{
	Task<Weapon?> GetById(int id);
	Task<IEnumerable<Weapon>> GetByIds(IEnumerable<int> ids);
	Task<int> Insert(Weapon weapon);
}