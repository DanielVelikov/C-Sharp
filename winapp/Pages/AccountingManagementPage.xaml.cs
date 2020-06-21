using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using winapp.Pages.Accounting_Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountingManagementPage : Page
    {
        private CTransactionsTable transactionsTable = App.workObjects.transactionsTable;

        public AccountingManagementPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.navigarionListBox.SelectedIndex = 3;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            App.workObjects.transactionsTable.RefreshData();
        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AccountingManagementPage));
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionDialog addTransactionDialog = new AddTransactionDialog();
            addTransactionDialog.ShowAsync();
        }

        private void UpdateTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (TransactionListView.SelectedItem == null) return;

            long ID = ((Transactions)TransactionListView.SelectedItem).lID;
            long updateCounter = ((Transactions)TransactionListView.SelectedItem).lUpdateCounter;
            string name = ((Transactions)TransactionListView.SelectedItem).szName;
            double amount = ((Transactions)TransactionListView.SelectedItem).dAmount;
            DateTime date = ((Transactions)TransactionListView.SelectedItem).TransactionDate;
            long transactionTypeID = ((Transactions)TransactionListView.SelectedItem).lTransactionTypeID;
            long accountID = ((Transactions)TransactionListView.SelectedItem).lAccountID;
            long projectID = ((Transactions)TransactionListView.SelectedItem).lProjectID;

            Transactions newTransaction = new Transactions((int)ID, (int)updateCounter, name, (int)transactionTypeID,
                (int)accountID, amount, date, (int)projectID);

            UpdateTransactionDialog updateTransaction = new UpdateTransactionDialog(newTransaction);
            updateTransaction.ShowAsync();
        }
    }
}
