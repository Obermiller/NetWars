namespace NetWars.API.Models;

public class PostResult
{
	public long Created { get; set; }
	public List<string> Errors { get; set; } = new();
}