using DatabaseImplementor.DatabaseProviders.MySQLManager;
using DatabaseImplementor.DatabaseProviders.OracleManager;
using DatabaseImplementor.DatabaseProviders.SQLManager;
using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;

namespace DatabaseImplementor.DatabaseProviders.ConnectionManager
{
	public class ConnectionHelper
	{
		private DatabaseProviderBase DatabaseProviderBase = default;

		public void Connect(string connectionString, DatabaseProvider databaseProvider)
		{
			switch (databaseProvider)
			{
				case DatabaseProvider.MySQL:

					DatabaseProviderBase = new MySQLHelper(connectionString);

					break;

				case DatabaseProvider.Oracle:

					DatabaseProviderBase = new OracleHelper(connectionString);

					break;

				case DatabaseProvider.SQLServer:

					DatabaseProviderBase = new SQLHelper(connectionString);

					break;
			}
		}
	}
}