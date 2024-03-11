using Dapper;
using DatabaseImplementor.DatabaseProviders.ConnectionManager;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;

namespace DatabaseImplementor.DatabaseProviders.SQLManager
{
	public class SQLHelper : DatabaseProviderBase, IConsumeQueries, IConsumeProcedures
	{
		public override string ConnectionString { get; set; }

		public override DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.SQLServer;

		public SQLHelper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public TResult Get<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using SqlConnection sqlConnection = new(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			TResult result = sqlConnection.QueryFirst<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public IEnumerable<TResult> GetAll<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using SqlConnection sqlConnection = new(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			IEnumerable<TResult> result = sqlConnection.Query<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using SqlConnection sqlConnection = new(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			IEnumerable<TResult> result = await sqlConnection.QueryAsync<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public async Task<TResult> GetAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using SqlConnection sqlConnection = new(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			TResult result = await sqlConnection.QueryFirstAsync<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public TResult Query<TResult>(string query)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			TResult result = sqlConnection.QueryFirst<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public IEnumerable<TResult> QueryAll<TResult>(string query)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			IEnumerable<TResult> result = sqlConnection.Query<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string query)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			IEnumerable<TResult> result = await sqlConnection.QueryAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public async Task<TResult> QueryAsync<TResult>(string query)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			TResult result = await sqlConnection.QueryFirstAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public int Execute(string sql)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			int result = sqlConnection.Execute(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}

		public async Task<int> ExecuteAsync(string sql)
		{
			using SqlConnection sqlConnection = new(ConnectionString);

			int result = await sqlConnection.ExecuteAsync(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			SqlConnection.ClearPool(sqlConnection);

			return result;
		}
	}
}