using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Classes
{
    class CLogIn : CBaseTable
    {
        internal Boolean SelectUser(string username, string password)
        {
            try
            {
                OpenDatabaseConnection();
                this.Query = String.Format("SELECT * FROM USERS WHERE USERNAME = '{0}' AND [PASSWORD] = '{1}'", username, password);
                this.Statement = new System.Data.SqlClient.SqlCommand(Query, Connection);
                this.dataReader = this.Statement.ExecuteReader();
            }
            catch(Exception e)
            {
                return false;
            }

            if (this.dataReader == null || !this.dataReader.HasRows) return false;
            CloseDatabaseConnection();
            return true;
        }
    }
}
