using APCRM.Web.Common;
using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APCRM.Web.DataAccess
{
    public class DataProvider : IDataProvider
    {

        private readonly ISqlProvider _provider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider"></param>
        public DataProvider(ISqlProvider provider)
        {
            _provider = provider;
        }

        #region Event
        public IEnumerable<Event> GetAllEvents()
        {
            //GetEvents
            
            return Helper.DatatableToList<Event>(_provider.SqlExecuteReader(StoredProcedure.GetEvents, new List<SqlParameter> { _provider.BuildSqlParamater("@EventID", SqlDbType.Int, null) }, true));
        }

        public Event GetEvent(int id)
        {
            return Helper.DatatableToList<Event>(_provider.SqlExecuteReader(StoredProcedure.GetEvents, new List<SqlParameter> { _provider.BuildSqlParamater("@EventID", SqlDbType.Int, null) }, true)).FirstOrDefault();
        }

        public void UpdateCustomer(CustomerDetails customer)
        {
            _provider.SqlExecuteNonQuery(StoredProcedure.UpdateCustomer, new List<SqlParameter> { _provider.BuildSqlParamater("@CustomerId", SqlDbType.NVarChar, customer.CustomerName) });
        }

        public void UpsertEvent(Event events)
        {
            if(events!=null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    _provider.BuildSqlParamater("@EventID",SqlDbType.Int,events.Id),
                    _provider.BuildSqlParamater("@EventTitle", SqlDbType.NVarChar,events.EventTitle),
                    _provider.BuildSqlParamater("@EventTypeId",SqlDbType.Int,events.EventTypeId),
                    _provider.BuildSqlParamater("@CustomerId",SqlDbType.Int,events.CustomerId),
                    _provider.BuildSqlParamater("@EventStartDate",SqlDbType.DateTime,events.EventStartDate),
                    _provider.BuildSqlParamater("@EventEndDate",SqlDbType.DateTime,events.EventEndDate),
                    _provider.BuildSqlParamater("@UpdatedBy",SqlDbType.NVarChar,events.UpdatedBy)
                };

                _provider.SqlExecuteNonQuery(StoredProcedure.UpsertEvents, parameters);
            }
        }
        #endregion
    }
}
