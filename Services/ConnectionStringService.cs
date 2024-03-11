namespace DatabaseImplementor.Services
{
	public class ConnectionStringService
	{
		private static ConnectionStringService Instance;

		private string ConnectionString;

		private readonly string DefaultConnectionString = string.Empty;

		private ConnectionStringService()
		{
			ConnectionString = DefaultConnectionString;
		}

		// Method to get the single instance of the class
		public static ConnectionStringService GetInstance()
		{
			Instance ??= new ConnectionStringService();

			return Instance;
		}

		// Implementation of the interface
		public string GetConnectionString()
		{
			return ConnectionString;
		}

		public void SetConnectionString(string connectionString)
		{
			ConnectionString = connectionString;
		}
	}
}