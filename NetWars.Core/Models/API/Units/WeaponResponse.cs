using NetWars.Core.Models.Schema.Units;

namespace NetWars.Core.Models.API.Units;

public class WeaponResponse : Weapon
{
	public string TargetDescription { get; set; } = string.Empty;
}