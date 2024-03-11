using static DatabaseImplementor.DatabaseProviders.ConnectionManager.DatabaseProvidersEnums;

namespace DatabaseImplementor
{
	public abstract class DatabaseProviderBase
	{
		public abstract string ConnectionString { get; set; }

		public abstract DatabaseProvider DatabaseProvider { get; set; }
	}
}