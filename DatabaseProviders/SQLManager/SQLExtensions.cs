using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DatabaseImplementor.DatabaseProviders.SQLManager
{
	public static class SQLExtensions
	{
		public static DynamicParameters ParseDynamic<T>(this T self)
		{
			if (self == null)
			{
				return new DynamicParameters();
			}

			List<PropertyInfo> properties = self.GetType().GetProperties().ToList();
			DynamicParameters parameters = new DynamicParameters();

			properties.ForEach(property =>
			{
				object value = property.GetValue(self);
				string fullName = property.PropertyType.FullName;

				DbType dbType = SQLDictionaries.DbTypeToCSharpTypes[fullName];

				parameters.Add(property.Name, value, dbType);
			});

			return parameters;
		}

	}
}