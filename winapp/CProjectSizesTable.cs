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
    internal class CProjectSizesTable : CBaseTable
    {
        internal override void SelectAll()
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "PROJECT_SIZES");
            this.dataReader = this.Statement.ExecuteReader();
            ProjectSizes temp;
            while (dataReader.Read())
            {
                temp = new ProjectSizes(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1)
                                               );
                this.ProjectSizesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedProjectSize)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "PROJECT_SIZES", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            ProjectSizes temp = new ProjectSizes(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1)
                                                );
            selectedProjectSize = temp;
            CloseDatabaseConnection();
        }

        internal CProjectSizesTable()
        {
            this.SelectAll();
        }
        internal ObservableCollection<ProjectSizes> ProjectSizesList = new ObservableCollection<ProjectSizes>();
    }
}
