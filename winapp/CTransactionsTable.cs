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
    internal class CTransactionsTable: CTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "TRANSACTIONS");
            this.dataReader = this.Statement.ExecuteReader();
            Transactions temp;
            while (dataReader.Read())
            {
                temp = new Transactions(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3),
                                               dataReader.GetValue(4),
                                               dataReader.GetValue(5),
                                               dataReader.GetValue(6),
                                               dataReader.GetValue(7)
                                               );
                temp.szTransactionTypeName = ((TransactionTypes)(App.workObjects.transactionTypesTable.TransactionTypesList.Where(x => x.lID.Equals(temp.lTransactionTypeID))).First()).szName;
                temp.szAccountName = ((Accounts)(App.workObjects.accountsTable.AccountsList.Where(x => x.lID.Equals(temp.lAccountID))).First()).szName;
                temp.szProjectName = ((Projects)(App.workObjects.projectsTable.ProjectsList.Where(x => x.lID.Equals(temp.lProjectID))).First()).szName;
                this.TransactionsList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedTransaction)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "TRANSACTIONS", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            Transactions temp = new Transactions(
                                            dataReader.GetValue(0),
                                            dataReader.GetValue(1),
                                            dataReader.GetValue(2),
                                            dataReader.GetValue(3),
                                            dataReader.GetValue(4),
                                            dataReader.GetValue(5),
                                            dataReader.GetValue(6),
                                            dataReader.GetValue(7)
                                            );
            selectedTransaction = temp;
            CloseDatabaseConnection();
        }

        internal override void InsertRecord(object newTransaction)
        {
            Transactions newTrans = (Transactions)newTransaction;
            OpenDatabaseConnection();

            Statement = new SqlCommand("INSERT INTO TRANSACTIONS(UPDATE_COUNTER, NAME, TRANSACTION_TYPE_ID, ACCOUNT_ID," +
                " AMOUNT, DATE, PROJECT_ID) " +
                "VALUES(@UPDATE_COUNTER, @NAME, @TRANSACTION_TYPE_ID, @ACCOUNT_ID, @AMOUNT, @DATE, @PROJECT_ID)", Connection);
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", newTrans.getUpdateCounter());
            Statement.Parameters.AddWithValue("@NAME", newTrans.getName());
            Statement.Parameters.AddWithValue("@TRANSACTION_TYPE_ID", newTrans.getTransactionTypeID());
            Statement.Parameters.AddWithValue("@ACCOUNT_ID", newTrans.getAccountID());
            Statement.Parameters.AddWithValue("@AMOUNT", newTrans.getAmount());
            Statement.Parameters.AddWithValue("@DATE", newTrans.getDate());
            Statement.Parameters.AddWithValue("@PROJECT_ID", newTrans.getProjectID());
            Statement.ExecuteNonQuery();

            CloseDatabaseConnection();
        }

        internal override Boolean UpdateWhereID(long lID, object newTransaction)
        {
            Transactions newTrans = (Transactions)newTransaction;
            OpenDatabaseConnection();
            this.setTransaction();

            Query = String.Format("UPDATE TRANSACTIONS WITH(XLOCK, ROWLOCK) SET [UPDATE_COUNTER] = @UPDATE_COUNTER, " +
                "[NAME] =  @NAME, " +
                "[TRANSACTION_TYPE_ID] = @TRANSACTION_TYPE_ID," +
                "[ACCOUNT_ID] = @ACCOUNT_ID, " +
                "[AMOUNT] = @AMOUNT, " +
                "[DATE] = @DATE, " +
                "[PROJECT_ID] = @PROJECT_ID " +
                "WHERE [ID] = '{0}';",
                 lID);

            Statement.CommandText = Query;
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", newTrans.getUpdateCounter() + 1);
            Statement.Parameters.AddWithValue("@NAME", newTrans.getName());
            Statement.Parameters.AddWithValue("@TRANSACTION_TYPE_ID", newTrans.getTransactionTypeID());
            Statement.Parameters.AddWithValue("@ACCOUNT_ID", newTrans.getAccountID());
            Statement.Parameters.AddWithValue("@AMOUNT", newTrans.getAmount());
            Statement.Parameters.AddWithValue("@DATE", newTrans.getDate());
            Statement.Parameters.AddWithValue("@PROJECT_ID", newTrans.getProjectID());

            

                Statement.ExecuteNonQuery();
                transaction.Commit();

            CloseDatabaseConnection();
            return true;
        }

        internal override void DeleteWhereID(long lID)
        {
            ExecuteCommand(DELETE_RECORD, "TRANSACTIONS", lID);
            this.Statement.ExecuteNonQuery();
            CloseDatabaseConnection();
        }

        protected override void ClearData()
        {
            TransactionsList.Clear();
        }

        internal override void RefreshData()
        {
            this.ClearData();
            this.SelectAll();
        }

        internal CTransactionsTable()
        {
            this.SelectAll();
        }

        internal ObservableCollection<Transactions> TransactionsList = new ObservableCollection<Transactions>();
    }
}
