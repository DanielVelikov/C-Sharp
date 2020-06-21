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
    internal class CCitiesTable: CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "CITIES");
            this.dataReader = this.Statement.ExecuteReader();
            Cities temp;
            while (dataReader.Read())
            {
                temp = new Cities(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3)
                                               );
                this.CitiesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedCity)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "CITIES", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            Cities temp = new Cities(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1),
                                                dataReader.GetValue(2),
                                                dataReader.GetValue(3));
            selectedCity = temp;
            CloseDatabaseConnection();
        }
        protected override void ClearData()
        {
            CitiesList.Clear();
        }

        internal CCitiesTable()
        {
            this.SelectAll();
        }
        internal ObservableCollection<Cities> CitiesList = new ObservableCollection<Cities>();
    }
}
