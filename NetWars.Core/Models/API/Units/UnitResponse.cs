using NetWars.Core.Models.Schema.Units;

namespace NetWars.Core.Models.API.Units;

public class UnitResponse : Unit
{
	public Weapon? PrimaryWeapon { get; set; }
	public Weapon? SecondaryWeapon { get; set; }
}