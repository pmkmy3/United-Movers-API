using System.Data;

namespace united_movers_api.Common
{
    public class Utils
    {
        public static IDataParameter AddParameter(IDbCommand command, string parameterName, object value, DbType dbType)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            parameter.DbType = dbType;
            return parameter;
        }
    }
}
