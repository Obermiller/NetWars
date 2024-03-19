namespace NetWars.Core.Enums.Units;

[Flags]
public enum MovementType : long
{
	None = 0,
	FootBasic = 1 << 0,
	FootAdvanced = 1 << 1,
	Tires = 1 << 2,
	Treads = 1 << 3,
	Plane = 1 << 4,
	Copter = 1 << 5,
	Naval = 1 << 6
}