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
    internal class CAccountsTable: CTable
    {
        internal void SelectWhereCompanyID(long CompanyID)
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "ACCOUNTS");
            String subQuery = String.Format(" WHERE COMPANY_ID = {0}", CompanyID);
            this.Query += subQuery;
            Statement = new SqlCommand(Query, Connection);
            this.dataReader = this.Statement.ExecuteReader();
            Accounts temp;
            while (dataReader.Read())
            {
                temp = new Accounts(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3),
                                               dataReader.GetValue(4)
                                               );
                this.AccountsList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedAccount)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "ACCOUNTS", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            Accounts account = new Accounts(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1),
                                                dataReader.GetValue(2),
                                                dataReader.GetValue(3),
                                                dataReader.GetValue(4));
            selectedAccount = account;
            CloseDatabaseConnection();
        }

        internal override void InsertRecord(object newAccount)
        {
            OpenDatabaseConnection();
            Accounts Account = (Accounts)newAccount;
            Statement = new SqlCommand("INSERT INTO COMPANIES(UPDATE_COUNTER, NAME, ACCOUNT_TYPE_ID, COMPANY_ID) " +
                "VALUES(@UPDATE_COUNTER, @NAME, @ACCOUNT_TYPE_ID, @COMPANY_ID)", Connection);
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Account.getUpdateCounter());
            Statement.Parameters.AddWithValue("@NAME", Account.getName());
            Statement.Parameters.AddWithValue("@REGION", Account.getAccountTypeID());
            Statement.Parameters.AddWithValue("@NAME", Account.getCompanyID());
            Statement.ExecuteNonQuery();

            CloseDatabaseConnection();
        }

        internal override Boolean UpdateWhereID(long lID, object newAccount)
        {
            Accounts Account = (Accounts)newAccount;
            Query = "";
            Query = String.Format("UPDATE ACCOUNTS WITH(XLOCK, ROWLOCK) SET [UPDATE_COUNTER] = @UPDATE_COUNTER, " +
                "[NAME] =  @NAME, " +
                "[ACCOUNT_TYPE_ID] = @ACCOUNT_TYPE_ID," +
                "[COMPANY_ID] =  @COMPANY_ID, " +
                "WHERE [ID] = '{0}';",
                 lID);

            OpenDatabaseConnection();
            Statement = new SqlCommand(Query, Connection);
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Account.getUpdateCounter() + 1);
            Statement.Parameters.AddWithValue("@NAME", Account.getName());
            Statement.Parameters.AddWithValue("@REGION", Account.getAccountTypeID());
            Statement.Parameters.AddWithValue("@COMPANY_ID", Account.getName());

            this.setTransaction();
            try
            {
                Statement.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        return false;
                    }
                }
                return false;
            }

            CloseDatabaseConnection();
            return true;
        }

        internal override void DeleteWhereID(long lID)
        {
            ExecuteCommand(DELETE_RECORD, "ACCOUNTS", lID);
            this.Statement.ExecuteNonQuery();
            CloseDatabaseConnection();
        }

        protected override void ClearData()
        {
            AccountsList.Clear();
        }

        internal ObservableCollection<Accounts> AccountsList = new ObservableCollection<Accounts>();
    }
}
