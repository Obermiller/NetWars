using System.Data;
using Microsoft.Extensions.Configuration;

namespace NetWars.Repositories;

public class SqlConnection
{
	private readonly IConfiguration _config;

	protected SqlConnection(IConfiguration config) => _config = config;
	
	protected IDbConnection CreateConnection()
	{
		var connectionString = _config.GetConnectionString("Default");
		
		var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
		conn.Open();
		
		return conn;
	}
}