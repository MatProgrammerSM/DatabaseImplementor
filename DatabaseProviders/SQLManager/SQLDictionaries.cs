using System.Collections.Generic;
using System.Data;

namespace DatabaseImplementor.DatabaseProviders.SQLManager
{
	public static class SQLDictionaries
	{
		public static readonly Dictionary<string, DbType> DbTypeToCSharpTypes = new()
		{
			{ "System.Byte[]", DbType.Binary },
			{ "System.Byte", DbType.Byte },
			{ "System.Boolean", DbType.Boolean },
			{ "System.DateTime", DbType.DateTime },
			{ "System.Decimal", DbType.Decimal },
			{ "System.Double", DbType.Double },
			{ "System.Guid", DbType.Guid },
			{ "System.Int16", DbType.Int16 },
			{ "System.Int32", DbType.Int32 },
			{ "System.Int64", DbType.Int64 },
			{ "System.Object", DbType.Object },
			{ "System.SByte", DbType.SByte },
			{ "System.Single", DbType.Single },
			{ "System.String", DbType.String },
			{ "System.TimeSpan", DbType.Time },
			{ "System.UInt16", DbType.UInt16 },
			{ "System.UInt32", DbType.UInt32 },
			{ "System.UInt64", DbType.UInt64 },
			{ "System.DateTimeOffset", DbType.DateTimeOffset }
		};
	}
}