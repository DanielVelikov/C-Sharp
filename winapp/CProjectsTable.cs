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
    internal class CProjectsTable: CTable
    {
        internal void SelectWhereCompanyID(long CompanyID)
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "PROJECTS");
            String subQuery = String.Format(" WHERE COMPANY_ID = '{0}'", CompanyID);
            this.Query += subQuery;
            Statement = new SqlCommand(Query, Connection);
            this.dataReader = this.Statement.ExecuteReader();
            Projects temp;
            while (dataReader.Read())
            {

                temp = new Projects(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3),
                                               dataReader.GetValue(4),
                                               dataReader.GetValue(5),
                                               dataReader.GetValue(6));

                temp.szProjectSizeName = ((ProjectSizes)(App.workObjects.projectSizesTable.ProjectSizesList.Where(x => x.lID.Equals(temp.lProjectSizeID))).First()).szProjectSize;
                ProjectsList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedProject)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "PROJECTS", lID);
            this.dataReader = this.Statement.ExecuteReader();

            dataReader.Read();
            Projects temp = new Projects(
                                            dataReader.GetValue(0),
                                            dataReader.GetValue(1),
                                            dataReader.GetValue(2),
                                            dataReader.GetValue(3),
                                            dataReader.GetValue(4),
                                            dataReader.GetValue(5),
                                            dataReader.GetValue(6)
                                            );
            selectedProject = temp;
            CloseDatabaseConnection();
        }

        internal override void InsertRecord(object newProject)
        {
            Projects Project = (Projects)newProject;
            OpenDatabaseConnection();

            Statement = new SqlCommand("INSERT INTO PROJECTS(UPDATE_COUNTER, NAME, COMPANY_ID, PROJECT_SIZE_ID, START_DATE, END_DATE) " +
                "VALUES(@UPDATE_COUNTER, @NAME, @COMPANY_ID, @PROJECT_SIZE_ID, @START_DATE, @END_DATE)", Connection);
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Project.getUpdateCounter());
            Statement.Parameters.AddWithValue("@NAME", Project.getName());
            Statement.Parameters.AddWithValue("@COMPANY_ID", Project.getCompanyID());
            Statement.Parameters.AddWithValue("@PROJECT_SIZE_ID", Project.getProjectSizeID());
            Statement.Parameters.AddWithValue("@START_DATE", Project.StartDate.Date);
            Statement.Parameters.AddWithValue("@END_DATE", Project.EndDate.Date);
            Statement.ExecuteNonQuery();

            CloseDatabaseConnection();
        }

        internal override Boolean UpdateWhereID(long lID, object newProject)
        {
            Projects Project = (Projects)newProject;

            OpenDatabaseConnection();
            this.setTransaction();

            Statement.CommandText="UPDATE PROJECTS WITH(XLOCK, ROWLOCK) SET [UPDATE_COUNTER] = @UPDATE_COUNTER, " +
                "[NAME] =  @NAME, [COMPANY_ID] = @COMPANY_ID, [PROJECT_SIZE_ID] = @PROJECT_SIZE_ID, [START_DATE] = @START_DATE, [END_DATE] = @END_DATE " +
                "WHERE ID = @ID";
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Project.getUpdateCounter() + 1);
            Statement.Parameters.AddWithValue("@NAME", Project.getName());
            Statement.Parameters.AddWithValue("@COMPANY_ID", Project.getCompanyID());
            Statement.Parameters.AddWithValue("@PROJECT_SIZE_ID", Project.getProjectSizeID());
            Statement.Parameters.AddWithValue("@START_DATE", Project.getStartDate());
            Statement.Parameters.AddWithValue("@END_DATE", Project.getEndDate());
            Statement.Parameters.AddWithValue("@ID", lID);

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
            ExecuteCommand(DELETE_RECORD, "PROJECTS", lID);
            this.Statement.ExecuteNonQuery();
            CloseDatabaseConnection();
        }

        protected override void ClearData()
        {
            ProjectsList.Clear();
        }

        internal override void RefreshData()
        {
            this.ClearData();
            this.SelectWhereCompanyID(App.userCompanyID);
        }

        internal CProjectsTable()
        {
            this.SelectWhereCompanyID(App.userCompanyID);
        }
       internal ObservableCollection<Projects> ProjectsList = new ObservableCollection<Projects>();
    }
}
