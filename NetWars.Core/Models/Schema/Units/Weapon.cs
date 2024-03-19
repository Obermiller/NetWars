using NetWars.Core.Enums.Units;

namespace NetWars.Core.Models.Schema.Units;

public class Weapon
{
	public long Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int MinimumRange { get; set; }
	public int MaximumRange { get; set; }
	public MovementType Targets { get; set; }
}