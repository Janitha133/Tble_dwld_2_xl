using REF_SITE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_SITE
{
    public class DL_Client
    {
        #region INSERT METHODS

        public void Insert(REF_Client oREF_Client, DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;

            try
            {
                sqlQuery = "SP_ADD_APPOINTMENT";
                oSqlCommand = new SqlCommand();

                oSqlCommand.Parameters.AddWithValue("@appointment_id", oREF_Client.APPOINTMENT_ID);
                oSqlCommand.Parameters.AddWithValue("@appointment_name", oREF_Client.APPOINTMENT_NAME);
                oSqlCommand.Parameters.AddWithValue("@parent", oREF_Client.PARENT);
                oSqlCommand.Parameters.AddWithValue("@limit_month", oREF_Client.LIMIT_MONTH);
                oSqlCommand.Parameters.AddWithValue("@limit_year", oREF_Client.LIMIT_YEAR);
                oSqlCommand.Parameters.AddWithValue("@status", oREF_Client.STATUS);
                oSqlCommand.Parameters.AddWithValue("@created_by", oREF_Client.CREATED_BY);
                oSqlCommand.Parameters.AddWithValue("@created_date", oREF_Client.CREATED_DATE);
                oSqlCommand.Parameters.AddWithValue("@modified_by", oREF_Client.MODIFIED_BY);
                oSqlCommand.Parameters.AddWithValue("@modified_date", oREF_Client.MODIFIED_DATE);

                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region SELECT METHODS
        public DataTable Select(DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            DataTable oDataTable = new DataTable();
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SP_GET_APPOINTMENT";
                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectAppToDrop(DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            DataTable oDataTable = new DataTable();
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SP_GET_AppToDrop";
                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectOne(string _ap_id, DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            DataTable oDataTable2 = new DataTable();

            try
            {
                sqlQuery = "SP_GET_APP_BY_APP_ID";
                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@appointment_id", _ap_id);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();

                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable2);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oDataTable2;
        }

        #endregion

        #region DELETE METHODS

        public void DeleteOne(string _dlt_ap_id, DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;

            try
            {
                sqlQuery = "SP_DELETE_appointment";
                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@appointment_id", Convert.ToInt32(_dlt_ap_id));
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();

                oSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
