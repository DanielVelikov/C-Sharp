using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp;

namespace winapp.Classes
{
    internal class CTableObjects
    {
        internal void loadProjects()
        {
            projectsTable = new CProjectsTable();
        }

        internal void loadTransactions()
        {
            transactionsTable = new CTransactionsTable();
        }

        internal void loadAccounts()
        {
            accountsTable.SelectWhereCompanyID(App.userCompanyID);
        }

        internal CAccountTypes accountTypes = new CAccountTypes();
        internal CCitiesTable citiesTable = new CCitiesTable();
        internal CFieldsTable fieldsTable = new CFieldsTable();
        internal CProjectSizesTable projectSizesTable = new CProjectSizesTable();
        internal CTransactionTypesTable transactionTypesTable = new CTransactionTypesTable();
        internal CAccountsTable accountsTable = new CAccountsTable();
        internal CCompaniesTable companiesTable = new CCompaniesTable();

        internal CProjectsTable projectsTable;
        internal CTransactionsTable transactionsTable;
    }
}
