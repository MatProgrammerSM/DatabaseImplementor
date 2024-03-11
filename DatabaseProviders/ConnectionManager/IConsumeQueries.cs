using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseImplementor.DatabaseProviders.ConnectionManager
{
	public interface IConsumeQueries
	{
		public TResult Query<TResult>(string query);

		public Task<TResult> QueryAsync<TResult>(string query);

		public IEnumerable<TResult> QueryAll<TResult>(string query);

		public Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string query);

		public int Execute(string sql);

		public Task<int> ExecuteAsync(string sql);
	}
}