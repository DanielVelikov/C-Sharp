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
    internal class CAccountTypes: CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "ACCOUNT_TYPES");
            this.dataReader = this.Statement.ExecuteReader();
            AccountTypes temp;
            while (dataReader.Read())
            {
                temp = new AccountTypes(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1)
                                               );
                this.AccountTypesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedAccounType)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "ACCOUNT_TYPES", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            AccountTypes temp = new AccountTypes(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1)
                                                );
            selectedAccounType = temp;
            CloseDatabaseConnection();
        }

        internal CAccountTypes()
        {
            this.SelectAll();
        }
        ObservableCollection<AccountTypes> AccountTypesList = new ObservableCollection<AccountTypes>();
    }
}
