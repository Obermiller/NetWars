namespace NetWars.Logic.Identity.Contracts;

public interface ITokenLogic
{
	Guid? GetUserId(string? header);
}