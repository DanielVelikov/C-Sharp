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
    internal class CFieldsTable: CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "FIELDS");
            this.dataReader = this.Statement.ExecuteReader();
            Fields temp;
            while (dataReader.Read())
            {
                temp = new Fields(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3)
                                               );
                temp.szImage = "TableImages/";
                temp.szImage += temp.getName() + ".png" ;
                this.FieldsList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedField)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "FIELDS", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            Fields temp = new Fields(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1),
                                                dataReader.GetValue(2),
                                                dataReader.GetValue(3)
                                                );
            selectedField = temp;
            CloseDatabaseConnection();
        }

        protected override void ClearData()
        {
            FieldsList.Clear();
        }

        internal CFieldsTable()
        {
            this.SelectAll();
        }
       internal ObservableCollection<Fields> FieldsList = new ObservableCollection<Fields>();
    }
}
