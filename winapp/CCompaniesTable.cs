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
    internal class CCompaniesTable : CTable
    {
        internal void SelectWhereFieldID(long fieldID)
        {
            ClearData();
            this.ExecuteCommand(SELECT_ALL_FROM_TABLE, "COMPANIES");
            String subQuery = String.Format(" WHERE FIELD_ID = {0}", fieldID);
            this.Query += subQuery;
            Statement = new SqlCommand(Query, Connection);
            this.dataReader = this.Statement.ExecuteReader();
            Companies temp;
            while (dataReader.Read())
            {
                temp = new Companies(
                                               dataReader.GetValue(0),
                                               dataReader.GetValue(1),
                                               dataReader.GetValue(2),
                                               dataReader.GetValue(3),
                                               dataReader.GetValue(4),
                                               dataReader.GetValue(5)
                                               );
                temp.szCityName = ((Cities)(citiesTable.CitiesList.Where(x => x.lID.Equals(temp.lCityID))).First()).getName();
                this.CompaniesList.Add(temp);
            }
            CloseDatabaseConnection();
        }

        internal override void SelectWhereID(long lID, ref object selectedCompany)
        {
            ExecuteCommand(SELECT_SINGLE_RECORD, "COMPANIES", lID);
            this.dataReader = this.Statement.ExecuteReader();
            dataReader.Read();
            Companies temp = new Companies(
                                                dataReader.GetValue(0),
                                                dataReader.GetValue(1),
                                                dataReader.GetValue(2),
                                                dataReader.GetValue(3),
                                                dataReader.GetValue(4),
                                                dataReader.GetValue(5)
                                                );
            selectedCompany = temp;
            CloseDatabaseConnection();
        }

        internal override void InsertRecord(object newCompany)
        {
            OpenDatabaseConnection();
            Companies Company = (Companies)newCompany;

            Statement = new SqlCommand("INSERT INTO COMPANIES(UPDATE_COUNTER, NAME, CITY_ID, FIELD_ID, ADDRESS) " +
                "VALUES(@UPDATE_COUNTER, @NAME, @CITY_ID, @FIELD_ID, @ADDRESS)", Connection);
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Company.getUpdateCounter());
            Statement.Parameters.AddWithValue("@NAME", Company.getName());
            Statement.Parameters.AddWithValue("@CITY_ID", Company.getCityID());
            Statement.Parameters.AddWithValue("@FIELD_ID", Company.getFieldID());
            Statement.Parameters.AddWithValue("@ADDRESS", Company.getAddress());

            Statement.ExecuteNonQuery();
            CloseDatabaseConnection();
        }

        internal override Boolean UpdateWhereID(long lID, object newCompany)
        {
            Companies Company = (Companies)newCompany;
            Query = "";
            Query = String.Format("UPDATE COMPANIES WITH(XLOCK, ROWLOCK) SET [UPDATE_COUNTER] = @UPDATE_COUNTER, " +
                "[NAME] =  @NAME, " +
                "[CITY_ID] = @CITY_ID," +
                "[FIELD_ID] = @FIELD_ID, " +
                "[ADDRESS] = @ADDRESS " +
                "WHERE [ID] = '{0}';",
                 lID);

            OpenDatabaseConnection();
            this.setTransaction();
            // Statement = new SqlCommand(Query, Connection);
            Statement.CommandText = Query;
            Statement.Parameters.AddWithValue("@UPDATE_COUNTER", Company.getUpdateCounter() + 1);
            Statement.Parameters.AddWithValue("@NAME", Company.getName());
            Statement.Parameters.AddWithValue("@CITY_ID", Company.getCityID());
            Statement.Parameters.AddWithValue("@FIELD_ID", Company.getFieldID());
            Statement.Parameters.AddWithValue("@ADDRESS", Company.getAddress());

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
            ExecuteCommand(DELETE_RECORD, "COMPANIES", lID);
            this.Statement.ExecuteNonQuery();
            CloseDatabaseConnection();
        }

        protected override void ClearData()
        {
            if (CompaniesList != null) CompaniesList.Clear();
        }

        internal ObservableCollection<Companies> CompaniesList = new ObservableCollection<Companies>();
        private CCitiesTable citiesTable = new CCitiesTable();
    }
}
