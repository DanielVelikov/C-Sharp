using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp.Classes;

namespace winapp.Classes
{
    public class CTransactionsAccountChart
    {
        internal CTransactionsAccountChart(string name)
        {
            transactionAccountName = name;
            countTransactions();
        }

        private void countTransactions()
        {
            long transactionAccountID = ((Accounts)(App.workObjects.accountsTable.AccountsList.Where(x => x.szName.Equals(transactionAccountName))).First()).lID;
            transactionsCount = App.workObjects.transactionsTable.TransactionsList.Count(n => n.lAccountID == transactionAccountID);
        }

        public string transactionAccountName { get; set; }
        public int transactionsCount { get; set; }
    }
}
