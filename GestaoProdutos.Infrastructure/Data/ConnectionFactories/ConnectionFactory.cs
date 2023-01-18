using GestaoProdutos.Domain.Core.Interfaces.ConnectionFactories;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GestaoProdutos.Infrastructure.Data.ConnectionFactories
{
	public class ConnectionFactory : IConnectionFactory
	{
		public async Task<IDbConnection> AbrirConexaoAsync(string banco, bool webConfig = false, string dbAddress = null)
		{
			string serverAddress, userID, password;

			serverAddress = dbAddress ?? Environment.GetEnvironmentVariable("DB_ADDRESS");
			userID = Environment.GetEnvironmentVariable("DB_USER_ID") ?? "sa";
			password = Environment.GetEnvironmentVariable("DB_PASSWORD");


			var connection = new SqlConnection($"Data Source={serverAddress};Initial Catalog={banco};Persist Security Info=True;User ID={userID};Password={password};MultipleActiveResultSets=True;");

			await connection.OpenAsync();

			return connection;
		}

		public static async Task<IDbConnection> ConexaoAsync(string banco, bool webConfig = false, string dbAddress = null)
		{
			return await new ConnectionFactory().AbrirConexaoAsync(banco, webConfig, dbAddress);
		}

		public IDbConnection AbrirConexao(string banco, bool webConfig = false, string dbAddress = null)
		{
			string serverAddress, userID, password;


			serverAddress = dbAddress ?? Environment.GetEnvironmentVariable("DB_ADDRESS");
			userID = Environment.GetEnvironmentVariable("DB_USER_ID") ?? "sa";
			password = Environment.GetEnvironmentVariable("DB_PASSWORD");


			var connection = new SqlConnection($"Data Source={serverAddress};Initial Catalog={banco};Persist Security Info=True;User ID={userID};Password={password};");

			connection.Open();

			return connection;
		}

		public static IDbConnection Conexao(string banco, bool webConfig = false, string dbAddress = null)
		{
			return new ConnectionFactory().AbrirConexao(banco, webConfig, dbAddress);
		}
	}
}