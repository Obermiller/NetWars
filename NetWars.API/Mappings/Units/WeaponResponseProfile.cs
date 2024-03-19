using AutoMapper;
using NetWars.Core.Models.API.Units;
using NetWars.Core.Models.Schema.Units;
using Obermiller.TypeExtensions;

namespace NetWars.API.Mappings.Units;

public class WeaponResponseProfile : Profile
{
	public WeaponResponseProfile()
	{
		CreateMap<Weapon, WeaponResponse>()
			.ForMember(api => api.TargetDescription, db => db.MapFrom(x => x.Targets.ToFlags().CommaJoin()));

		CreateMap<WeaponResponse, Weapon>();
	}
}