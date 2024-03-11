using DatabaseImplementor.DatabaseProviders.ConnectionManager;
using Dapper;
using DatabaseImplementor;
using MySql.Data.MySqlClient;
using System.Data;
using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseImplementor.DatabaseProviders.MySQLManager
{
	public class MySQLHelper : DatabaseProviderBase, IConsumeQueries, IConsumeProcedures
	{
		public override string ConnectionString { get; set; }

		public override DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.MySQL;

		public MySQLHelper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public TResult Get<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			TResult result = mySQLConnection.QueryFirst<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public IEnumerable<TResult> GetAll<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			IEnumerable<TResult> result = mySQLConnection.Query<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			IEnumerable<TResult> result = await mySQLConnection.QueryAsync<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public async Task<TResult> GetAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			TResult result = await mySQLConnection.QueryFirstAsync<TResult>(
				storeProcedure, request, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public TResult Query<TResult>(string query)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			TResult result = mySQLConnection.QueryFirst<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public IEnumerable<TResult> QueryAll<TResult>(string query)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			IEnumerable<TResult> result = mySQLConnection.Query<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string query)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			IEnumerable<TResult> result = await mySQLConnection.QueryAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public async Task<TResult> QueryAsync<TResult>(string query)
		{
			using var mySQLConnection = new MySqlConnection(ConnectionString);

			TResult result = await mySQLConnection.QueryFirstAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public int Execute(string sql)
		{
			using MySqlConnection mySQLConnection = new(ConnectionString);

			int result = mySQLConnection.Execute(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}

		public async Task<int> ExecuteAsync(string sql)
		{
			using MySqlConnection mySQLConnection = new(ConnectionString);

			int result = await mySQLConnection.ExecuteAsync(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			MySqlConnection.ClearPool(mySQLConnection);

			return result;
		}
	}
}