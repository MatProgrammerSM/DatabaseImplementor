using DatabaseImplementor.DatabaseProviders.ConnectionManager;
using DatabaseImplementor.DatabaseProviders.SQLManager;
using Dapper;
using DatabaseImplementor;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseImplementor.DatabaseProviders.OracleManager
{
	public class OracleHelper : DatabaseProviderBase, IConsumeQueries, IConsumeProcedures
	{
		public override string ConnectionString { get; set; }

		public override DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.Oracle;

		public OracleHelper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public TResult Get<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			TResult result = oracleConnection.QueryFirst<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public IEnumerable<TResult> GetAll<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			IEnumerable<TResult> result = oracleConnection.Query<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			IEnumerable<TResult> result = await oracleConnection.QueryAsync<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public async Task<TResult> GetAsync<TResult, TRequest>(TRequest request, string storeProcedure)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);
			DynamicParameters dynamicParameters = request.ParseDynamic();

			TResult result = await oracleConnection.QueryFirstAsync<TResult>(
				storeProcedure, dynamicParameters, commandTimeout: 0, commandType: CommandType.StoredProcedure
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public TResult Query<TResult>(string query)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);

			TResult result = oracleConnection.QueryFirst<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public IEnumerable<TResult> QueryAll<TResult>(string query)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);

			IEnumerable<TResult> result = oracleConnection.Query<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public async Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string query)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);

			IEnumerable<TResult> result = await oracleConnection.QueryAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public async Task<TResult> QueryAsync<TResult>(string query)
		{
			using OracleConnection oracleConnection = new OracleConnection(ConnectionString);

			TResult result = await oracleConnection.QueryFirstAsync<TResult>(
				query, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public int Execute(string sql)
		{
			using OracleConnection oracleConnection = new(ConnectionString);

			int result = oracleConnection.Execute(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}

		public async Task<int> ExecuteAsync(string sql)
		{
			using OracleConnection oracleConnection = new(ConnectionString);

			int result = await oracleConnection.ExecuteAsync(
				sql, commandTimeout: 0, commandType: CommandType.Text
			);
			OracleConnection.ClearPool(oracleConnection);

			return result;
		}
	}
}