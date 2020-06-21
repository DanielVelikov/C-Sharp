using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Classes
{
    internal class CTransactionCharts
    {

        internal CTransactionCharts()
        {
            setTransactionsChartsData();
        }

        private void setTransactionsChartsData()
        {
            foreach(TransactionTypes transactionType in App.workObjects.transactionTypesTable.TransactionTypesList)
            {
                transactionsTypeCharts.Add(new CTransactionTypeChart(transactionType.szName));
            }

            foreach(Accounts account in App.workObjects.accountsTable.AccountsList)
            {
                transactionsAccountCharts.Add(new CTransactionsAccountChart(account.szName));
            }

            foreach(Projects project in App.workObjects.projectsTable.ProjectsList)
            {
                transactionsProjectCharts.Add(new CTransactionsProjectChart(project.szName));
            }
        }
        internal List<CTransactionsProjectChart> transactionsProjectCharts = new List<CTransactionsProjectChart>();
        internal List<CTransactionsAccountChart> transactionsAccountCharts = new List<CTransactionsAccountChart>();
        internal List<CTransactionTypeChart> transactionsTypeCharts = new List<CTransactionTypeChart>();
    }
}
