using DapperExtensions;
using DapperExtensions.Predicate;
using Microsoft.Extensions.Configuration;
using NetWars.Core.Models.Schema.Units;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Repositories.Units;

public class WeaponRepository(IConfiguration config) : SqlConnection(config), IWeaponRepository
{
	public async Task<Weapon?> GetById(int id)
	{
		using var conn = CreateConnection();
		
		var weapon = await conn.GetAsync<Weapon>(new { Id = id });

		return weapon;
	}

	public async Task<IEnumerable<Weapon>> GetByIds(IEnumerable<int> ids)
	{
		using var conn = CreateConnection();
		
		var predicate = Predicates.Field<Weapon>(w => w.Id, Operator.Eq, ids);
		var weapons = await conn.GetListAsync<Weapon>(predicate);

		return weapons;
	}

	public async Task<int> Insert(Weapon weapon)
	{
		using var conn = CreateConnection();
		
		var id = await conn.InsertAsync(weapon);
		
		return id;
	}
}