using DatabaseImplementor.DatabaseProviders.ConnectionManager;
using Dapper;
using DatabaseImplementor;
using Npgsql;
using System.Data;
using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DatabaseImplementor.DatabaseProviders.PostgreSQLManager
{
	public  class PostgreSQLHelper : DatabaseProviderBase, IConsumeQueries, IConsumeProcedures
	{
		public override string ConnectionString { get; set; }

		public override DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.MySQL;

		public PostgreSQLHelper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public TResult Get<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using NpgsqlConnection connection = new(ConnectionString);

			TResult result = connection.QueryFirst<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public IEnumerable<TResult> GetAll<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using NpgsqlConnection connection = new(ConnectionString);

			IEnumerable<TResult> result = connection.Query<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			IEnumerable<TResult> result = await connection.QueryAsync<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public async Task<TResult> GetAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			TResult result = await connection.QueryFirstAsync<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public TResult Query<TResult>(string query)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			TResult result = connection.QueryFirst<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public IEnumerable<TResult> QueryAll<TResult>(string query)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			IEnumerable<TResult> result = connection.Query<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public async Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string query)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			IEnumerable<TResult> result = await connection.QueryAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public async Task<TResult> QueryAsync<TResult>(string query)
		{
			using var connection = new NpgsqlConnection(ConnectionString);

			TResult result = await connection.QueryFirstAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public int Execute(string sql)
		{
			using NpgsqlConnection connection = new(ConnectionString);

			int result = connection.Execute(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}

		public async Task<int> ExecuteAsync(string sql)
		{
			using NpgsqlConnection connection = new(ConnectionString);

			int result = await connection.ExecuteAsync(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			NpgsqlConnection.ClearPool(connection);

			return result;
		}
	}
}