using DapperExtensions;
using DapperExtensions.Predicate;
using Microsoft.Extensions.Configuration;
using NetWars.Core.Models.Schema.Units;
using NetWars.Repositories.Units.Contracts;

namespace NetWars.Repositories.Units;

public class WeaponRepository(IConfiguration config) : SqlConnection(config), IWeaponRepository
{
	public async Task<IEnumerable<Weapon>> GetAll()
	{
		using var conn = CreateConnection();
		return await conn.GetListAsync<Weapon>();
	}
	
	public async Task<Weapon?> GetById(int id)
	{
		using var conn = CreateConnection();

		//TODO
		try
		{
			return await conn.GetAsync<Weapon?>(new { Id = id });
		}
		catch (Exception)
		{
			return null;
		}
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

	public async Task<bool> Update(Weapon weapon)
	{
		var conn = CreateConnection();

		var updated = await conn.UpdateAsync(weapon);

		return updated;
	}
}