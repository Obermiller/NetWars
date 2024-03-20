using NetWars.Core.Models.Schema.Units;
using NetWars.Logic.Units.Contracts;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Logic.Units;

public class WeaponLogic(IWeaponRepository weaponRepository) : IWeaponLogic
{
	public async Task<List<Weapon>> GetAll()
	{
		var response = await weaponRepository.GetAll();

		return response.ToList();
	}
	
	public async Task<Weapon?> GetById(int id)
	{
		var response = await weaponRepository.GetById(id);

		return response;
	}

	public async Task<List<Weapon>> GetByIds(IEnumerable<int> ids)
	{
		var response = await weaponRepository.GetByIds(ids);
		
		return response.ToList();
	}

	public async Task<int> Insert(Weapon weapon) => await weaponRepository.Insert(weapon);

	public async Task<bool> Update(int id, Weapon weapon)
	{
		var dbWeapon = await GetById(id);
		if (dbWeapon is null)
		{
			throw new InvalidOperationException();
		}
		
		weapon.Id = id;
		return await weaponRepository.Update(weapon);
	}
}