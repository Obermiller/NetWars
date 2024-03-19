using AutoMapper;
using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;

namespace NetWars.API.Mappings.Units;

public class UnitResponseProfile : Profile
{
	public UnitResponseProfile()
	{
		CreateMap<Unit, UnitResponse>();

		CreateMap<UnitResponse, Unit>();
	}
}