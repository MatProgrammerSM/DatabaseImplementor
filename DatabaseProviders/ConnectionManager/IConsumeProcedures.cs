using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseImplementor.DatabaseProviders.ConnectionManager
{
	public interface IConsumeProcedures
	{
		public TResult Get<TResult, TRequest>(TRequest request, string storeProcedure);

		public Task<TResult> GetAsync<TResult, TRequest>(TRequest request, string storeProcedure);

		public IEnumerable<TResult> GetAll<TResult, TRequest>(TRequest request, string storeProcedure);

		public Task<IEnumerable<TResult>> GetAllAsync<TResult, TRequest>(TRequest request, string storeProcedure);
	}
}