using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_SITE;
using REF_SITE;

namespace BL_SITE
{
    public class BL_Client
    {
        #region INSERT METHODS

        public void Insert(REF_Client oREF_Client, DB_Handle oDB_Handle)
        {
            //**
            DL_Client oDL_Client = new DL_Client();

            try
            {
                bool newDBHandle = false;

                if (oDB_Handle == null)
                {
                    oDB_Handle = new DB_Handle();
                    oDB_Handle.OpenConnection();
                    oDB_Handle.BeginTransaction();
                    newDBHandle = true;
                }

                //**
                oDL_Client.Insert(oREF_Client, oDB_Handle);

                if (newDBHandle)
                {
                    oDB_Handle.CommitTransaction();
                    oDB_Handle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDB_Handle.RollbackTransaction();
                oDB_Handle.CloseConnection();
                throw ex;
            }
        }

        #endregion

        #region SELECT METHODS

        public DataTable Select(DB_Handle oDB_Handle)
        {
            DL_Client oDL_Client = new DL_Client();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDB_Handle == null)
                {
                    oDB_Handle = new DB_Handle();
                    oDB_Handle.OpenConnection();
                    oDB_Handle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDL_Client.Select(oDB_Handle);
                if (newDBHandle)
                {
                    oDB_Handle.CommitTransaction();
                    oDB_Handle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDB_Handle.RollbackTransaction();
                oDB_Handle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataTable SelectAppToDrop(DB_Handle oDB_Handle)
        {
            DL_Client oDL_Client = new DL_Client();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDB_Handle == null)
                {
                    oDB_Handle = new DB_Handle();
                    oDB_Handle.OpenConnection();
                    oDB_Handle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDL_Client.SelectAppToDrop(oDB_Handle);
                if (newDBHandle)
                {
                    oDB_Handle.CommitTransaction();
                    oDB_Handle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDB_Handle.RollbackTransaction();
                oDB_Handle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataTable SelectOne(String _ap_id, DB_Handle oDB_Handle)
        {
            DL_Client oDL_Client = new DL_Client();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;

                if (oDB_Handle == null)
                {
                    oDB_Handle = new DB_Handle();
                    oDB_Handle.OpenConnection();
                    oDB_Handle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDL_Client.SelectOne(_ap_id, oDB_Handle);

                if (newDBHandle)
                {
                    oDB_Handle.CommitTransaction();
                    oDB_Handle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDB_Handle.RollbackTransaction();
                oDB_Handle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        #endregion

        #region DELETE METHODS

        public void DeleteOne(String _dlt_ap_id, DB_Handle oDB_Handle)
        {
            DL_Client oDL_Client = new DL_Client();

            try
            {
                bool newDBHandle = false;

                if (oDB_Handle == null)
                {
                    oDB_Handle = new DB_Handle();
                    oDB_Handle.OpenConnection();
                    oDB_Handle.BeginTransaction();
                    newDBHandle = true;
                }
                oDL_Client.DeleteOne(_dlt_ap_id, oDB_Handle);

                if (newDBHandle)
                {
                    oDB_Handle.CommitTransaction();
                    oDB_Handle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDB_Handle.RollbackTransaction();
                oDB_Handle.CloseConnection();
                throw ex;
            }
        }

        #endregion
    }
}
