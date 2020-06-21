using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp.Classes;

namespace winapp
{
    internal class CTransactionTypesTable: CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "TRANSACTION_TYPES");
            this.dataReader = this.Statement.ExecuteReader();
            TransactionTypes temp;
            while (dataReader.Read())
            {
                temp = new TransactionTypes(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1)
                                               );
                this.TransactionTypesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedTransactionType)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "TRANSACTION_TYPES", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            TransactionTypes temp = new TransactionTypes(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1)
                                                );
            selectedTransactionType = temp;
            CloseDatabaseConnection();
        }

        internal CTransactionTypesTable()
        {
            this.SelectAll();
        }
        internal ObservableCollection<TransactionTypes> TransactionTypesList = new ObservableCollection<TransactionTypes>();
    }
}
