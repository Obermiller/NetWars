using NetWars.Core.Enums.Units;

namespace NetWars.Core.Models.Schema.Units;

public class Unit
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public DeploymentType DeploymentType { get; set; }
	public int Movement { get; set; }
	public MovementType MovementType { get; set; }
	public int Fuel { get; set; }
	public int Vision { get; set; }
	public int Price { get; set; }
	public int PrimaryWeaponId { get; set; }
	public int? SecondaryWeaponId { get; set; }
	public bool CanReplenish { get; set; }
	public MovementType CanTransport { get; set; }
	public bool CanRepair { get; set; }
	public bool CanHide { get; set; }
}