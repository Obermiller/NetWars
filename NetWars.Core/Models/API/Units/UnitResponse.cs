using NetWars.Core.Models.Schema.Units;

namespace NetWars.Core.Models.API.Units;

public class UnitResponse : Unit
{
	public WeaponResponse? PrimaryWeapon { get; set; }
	public WeaponResponse? SecondaryWeapon { get; set; }
}