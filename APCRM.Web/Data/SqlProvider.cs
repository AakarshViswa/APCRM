using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace APCRM.Web.Data
{
    public class SqlProvider : ISqlProvider
    {
        /// <summary>
        /// Sql Database Connection String
        /// </summary>
        public static string SqlConnectionString { get; set; }

        public SqlParameter BuildSqlParamater(string ParamName, SqlDbType type, object value)
        {
            var parameter = new SqlParameter(ParamName, type);
            switch (type)
            {
                case SqlDbType.Bit:
                case SqlDbType.Char:
                case SqlDbType.DateTime:
                case SqlDbType.Date:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                    parameter.Value = value?.ToString();
                    break;
                default:
                    parameter.Value = value;
                    break;
            }
            return parameter;
        }

        public void SqlExecuteNonQuery(string spname, IList<SqlParameter> sqlParameters)
        {
            using var connection = new SqlConnection(SqlConnectionString);

            connection.Open();
            using var command = new SqlCommand(spname, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(sqlParameters.ToArray());
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable SqlExecuteReader(string cmdtxt, IList<SqlParameter> sqlParameters, bool isStoredProcedure)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            using var command = new SqlCommand(cmdtxt, connection)
            {
                CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text
            };

            command.Parameters.AddRange(sqlParameters.ToArray());

            using var reader = command.ExecuteReader();
            var table = new DataTable();
            table.Locale=CultureInfo.InvariantCulture;
            table.Load(reader);

            connection.Close();

            return table;
        }

        public int SqlExecuteScalar(string spname, IList<SqlParameter> sqlParameters)
        {
            using var connection = new SqlConnection(SqlConnectionString);

            connection.Open();
            using var command = new SqlCommand(spname, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(sqlParameters.ToArray());

            int result = int.Parse(command.ExecuteScalar().ToString(), CultureInfo.InvariantCulture);

            connection.Close();

            return result;
        }
    }
}
