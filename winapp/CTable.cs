using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp.Classes;

namespace winapp
{
    internal class CTable: CBaseTable
    {

        protected void setTransaction()
        {
            Statement = Connection.CreateCommand();
            transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
            Statement.Connection = Connection;
            Statement.Transaction = transaction;
        }

        internal virtual Boolean UpdateWhereID(long ID, object updatedObject) { return false; }
        internal virtual void DeleteWhereID(long lID) { }
        internal virtual void InsertRecord(object newObject) { }
        internal virtual void RefreshData() { }

        internal SqlTransaction transaction;
    }
}
