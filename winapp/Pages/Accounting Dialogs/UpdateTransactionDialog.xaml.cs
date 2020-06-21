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
    public sealed partial class UpdateTransactionDialog : ContentDialog
    {
        public UpdateTransactionDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            transaction.szName = TransactionNameTextBox.Text;
            transaction.dAmount = Convert.ToDouble(TransactionAmountTextBox.Text);
            transaction.TransactionDate = Convert.ToDateTime(TransactionDateControl.Date.ToString());
            transaction.lTransactionTypeID = ((TransactionTypes)(TransactionTypeComboBox.SelectedItem)).lID;
            transaction.lAccountID = ((Accounts)(TransactionAccountComboBox.SelectedItem)).lID;
            transaction.lProjectID = ((Projects)(TransactionProjectComboBox.SelectedItem)).lID;

            App.workObjects.transactionsTable.UpdateWhereID(transaction.lID, transaction);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        internal UpdateTransactionDialog(Transactions newTransaction)
        {
            this.InitializeComponent();
            transaction = newTransaction;
        }

        private void setData()
        {
            TransactionNameTextBox.Text = transaction.szName;
            TransactionAmountTextBox.Text = transaction.dAmount.ToString();
            TransactionDateControl.Date = transaction.TransactionDate.Date;
            TransactionTypeComboBox.SelectedValue = transactionTypesTable.TransactionTypesList.Where(x => x.lID.Equals(transaction.lTransactionTypeID)).First();
            TransactionAccountComboBox.SelectedValue = accountsTable.AccountsList.Where(x => x.lID.Equals(transaction.lAccountID)).First();
            TransactionProjectComboBox.SelectedValue = projectsTable.ProjectsList.Where(x => x.lID.Equals(transaction.lProjectID)).First();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            setData();
        }

        Transactions transaction;
        private CTransactionTypesTable transactionTypesTable = App.workObjects.transactionTypesTable;
        private CAccountsTable accountsTable = App.workObjects.accountsTable;
        private CProjectsTable projectsTable = App.workObjects.projectsTable;
    }
}
