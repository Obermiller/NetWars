using AutoMapper;
using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;
using NetWars.Logic.Units.Contracts;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Logic.Units;

public class UnitLogic(IWeaponLogic weaponLogic, IUnitRepository unitRepository, IMapper mapper)
	: IUnitLogic
{
	public async Task<List<UnitResponse>> GetAll(bool includeSubobjects)
	{
		var units = await unitRepository.GetAll();
		var results = mapper.Map<List<UnitResponse>>(units);
		
		if (includeSubobjects)
		{
			var weaponIds = results
				.SelectMany(unit => new[] { unit.PrimaryWeaponId, unit.SecondaryWeaponId })
				.OfType<int>()
				.Distinct();
			
			var weapons = await weaponLogic.GetByIds(weaponIds);
			var weaponsById = weapons.ToDictionary(w => w.Id);
			
			foreach (var unit in results)
			{
				weaponsById.TryGetValue(unit.PrimaryWeaponId, out var primaryWeapon);
				unit.PrimaryWeapon = primaryWeapon ?? new Weapon();
				
				if (unit.SecondaryWeaponId is not null && weaponsById.TryGetValue(unit.SecondaryWeaponId.Value, out var secondaryWeapon))
				{
					unit.SecondaryWeapon = secondaryWeapon;
				}
			}
		}
		
		return results;
	}
}