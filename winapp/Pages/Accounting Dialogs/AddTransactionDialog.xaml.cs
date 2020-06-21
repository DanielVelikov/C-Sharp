using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using winapp.Classes;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages.Accounting_Dialogs
{
    public sealed partial class AddTransactionDialog : ContentDialog
    {
        public AddTransactionDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string name = TransactionNameTextBox.Text;
            double amount = Convert.ToDouble(TransactionAmountTextBox.Text);
            DateTime Date = Convert.ToDateTime(TransactionDateControl.Date.ToString());
            long transactionTypeID = ((TransactionTypes)(TransactionTypeComboBox.SelectedItem)).lID;
            long transactionAccountID = ((Accounts)(TransactionAccountComboBox.SelectedItem)).lID;
            long transactionProjectID = ((Projects)(TransactionProjectComboBox.SelectedItem)).lID;

            Transactions newTransaction = new Transactions(0, 0, name, (int)transactionTypeID, (int)transactionAccountID,
                amount, Date, (int)transactionProjectID);

            App.workObjects.transactionsTable.InsertRecord(newTransaction);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
        private CTransactionTypesTable transactionTypesTable = App.workObjects.transactionTypesTable;
        private CAccountsTable accountsTable = App.workObjects.accountsTable;
        private CProjectsTable projectsTable = App.workObjects.projectsTable;
    }
}
