using AutoMapper;
using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;
using NetWars.Logic.Units.Contracts;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Logic.Units;

public class WeaponLogic(IWeaponRepository weaponRepository, IMapper mapper) : IWeaponLogic
{
	public async Task<WeaponResponse?> GetById(int id)
	{
		var weapon = await weaponRepository.GetById(id);
		var response = mapper.Map<WeaponResponse>(weapon);

		return response;
	}

	public async Task<List<WeaponResponse>> GetByIds(IEnumerable<int> ids)
	{
		var weapons = await weaponRepository.GetByIds(ids);
		var response = mapper.Map<List<WeaponResponse>>(weapons);
		
		return response;
	}

	public async Task<int> Insert(Weapon weapon) => await weaponRepository.Insert(weapon);
}