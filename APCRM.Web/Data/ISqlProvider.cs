using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace APCRM.Web.Data
{
    public interface ISqlProvider
    {
        /// <summary>
        /// Execute SQL non query
        /// </summary>
        /// <param name="spname"></param>
        /// <param name="sqlParameters"></param>
        void SqlExecuteNonQuery(string spname, IList<SqlParameter> sqlParameters);

        /// <summary>
        /// Read first column of SQL data
        /// </summary>
        /// <param name="spname"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        int SqlExecuteScalar(string spname, IList<SqlParameter> sqlParameters);

        /// <summary>
        /// Returns Datatable of sql Data
        /// </summary>
        /// <param name="spname"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        DataTable SqlExecuteReader(string cmdtxt, IList<SqlParameter> sqlParameters,bool isStoredProcedure);

        /// <summary>
        /// Builds an SqlParameter based on the supplied values.
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        SqlParameter BuildSqlParamater(string ParamName, SqlDbType type, object value);
    }
}
