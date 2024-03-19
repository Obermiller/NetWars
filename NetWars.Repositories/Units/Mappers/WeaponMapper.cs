using DapperExtensions.Mapper;
using NetWars.Core.Models.Schema.Units;

namespace NetWars.Repositories.Units.Mappers;

public sealed class WeaponMapper : ClassMapper<Weapon>
{
	public WeaponMapper()
	{
		Table(nameof(Weapon));

		Map(x => x.Id).Key(KeyType.Assigned);
		
		AutoMap();
	}
}