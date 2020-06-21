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
    internal class CFieldTypesTable: CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "FIELD_TYPES");
            this.dataReader = this.Statement.ExecuteReader();
            FieldTypes temp;
            while (dataReader.Read())
            {
                temp = new FieldTypes(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1)
                                               );
                this.FieldTypesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal void SelectWhereID(long lID, ref FieldTypes selectedFieldType)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "FIELD_TYPES", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            FieldTypes temp = new FieldTypes(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1)
                                                );
            selectedFieldType = temp;
            CloseDatabaseConnection();
        }

        internal CFieldTypesTable()
        {
            this.SelectAll();
        }
        internal ObservableCollection<FieldTypes> FieldTypesList = new ObservableCollection<FieldTypes>();
    }
}
