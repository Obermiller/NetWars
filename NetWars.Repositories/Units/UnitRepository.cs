using DapperExtensions;
using Microsoft.Extensions.Configuration;
using NetWars.Core.Models.Schema.Units;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Repositories.Units;

public class UnitRepository(IConfiguration config) : SqlConnection(config), IUnitRepository
{
	public async Task<IEnumerable<Unit>> GetAll()
	{
		using var conn = CreateConnection();
		return await conn.GetListAsync<Unit>();
	}
}