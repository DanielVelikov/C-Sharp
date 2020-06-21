
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using winapp.Classes;

namespace winapp
{
    internal abstract class CBaseTable
    {
        internal Boolean OpenDatabaseConnection()
        {
            String ConnectionString;
            ConnectionString = @"Data Source = LAPTOP-TQKEGAVB; Initial Catalog = Accounting; User Id = ad; Password = ad";
            Connection = new SqlConnection(ConnectionString);

            this.Connection.Open();
            bool hresult = Connection.State == ConnectionState.Open;
            if (hresult != true)
            {
                CloseDatabaseConnection();
                return false;
            }

            return true;
        }

        internal void CloseDatabaseConnection()
        {
            if(dataReader!=null) dataReader.Close();
            if (Statement!=null) Statement.Dispose();
            Connection.Close();
        }

        internal Boolean ExecuteCommand(ushort command, string table, long index = 0,  Boolean bTransactionFlag = false)
        {

            if(OpenDatabaseConnection()==false)
            {
                CloseDatabaseConnection();
                return false;
            }

            Query = "";
            switch (command)
            {

                case SELECT_ALL_FROM_TABLE:
                    {
                        this.Query = String.Format("SELECT * FROM {0}", table);
                        break;
                    }

                case SELECT_SINGLE_RECORD:
                    {
                        this.Query = String.Format("SELECT * FROM {0} WHERE ID = '{1}'", table,index);
                        break;
                    }
                case DELETE_RECORD:
                    {
                        this.Query = String.Format("DELETE FROM {0} WHERE ID = '{1}'", table, index);
                        break;
                    }
                default:
                    {
                        //wrong command hadling
                        return false;
                    }
            }

            //execute 
            Statement = new SqlCommand(Query, Connection);
            return true;
        }

        internal virtual void SelectWhereID(long ID, ref object selectedObject) { }
        protected virtual void ClearData() { }
        internal virtual void SelectAll() { }

        internal SqlConnection Connection;
        internal SqlCommand Statement;
        internal SqlDataAdapter dataAdapter = new SqlDataAdapter();
        internal SqlDataReader dataReader;
        internal String Query;

        // case variables 
        protected const ushort SELECT_ALL_FROM_TABLE = 1;
        protected const ushort SELECT_SINGLE_RECORD = 2;
        protected const ushort DELETE_RECORD = 3;
    }
}
