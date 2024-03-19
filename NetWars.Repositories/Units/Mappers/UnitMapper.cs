using DapperExtensions.Mapper;
using NetWars.Core.Models.Schema.Units;

namespace NetWars.Repositories.Units.Mappers;

public sealed class UnitMapper : ClassMapper<Unit>
{
	public UnitMapper()
	{
		Table(nameof(Weapon));

		Map(x => x.Id).Key(KeyType.Assigned);
		
		AutoMap();
	}
}