using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Classes
{
    public class CTransactionTypeChart
    {
        internal CTransactionTypeChart(string name)
        {
            this.transactionTypeName = name;
            countTransactions();
        }

        private void countTransactions()
        {
            long transactionTypeID = ((TransactionTypes)(App.workObjects.transactionTypesTable.TransactionTypesList.Where(x => x.szName.Equals(transactionTypeName))).First()).lID;
            transactionsCount = App.workObjects.transactionsTable.TransactionsList.Count(n => n.lTransactionTypeID == transactionTypeID);
        }

        public string transactionTypeName { get; set; }
        public int transactionsCount { get; set; }
    }
}
