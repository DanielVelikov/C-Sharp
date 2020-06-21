using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Classes
{
    internal class CTransactionsProjectChart
    {
        internal CTransactionsProjectChart(string name)
        {
            transactionProjectName = name;
            countTransactions();
        }

        private void countTransactions()
        {
            long transactionProjectID = ((Projects)(App.workObjects.projectsTable.ProjectsList.Where(x => x.szName.Equals(transactionProjectName))).First()).lID;
            transactionsCount = App.workObjects.transactionsTable.TransactionsList.Count(n => n.lProjectID == transactionProjectID);
        }

        public string transactionProjectName { get; set; }
        public int transactionsCount { get; set; }
    }
}
