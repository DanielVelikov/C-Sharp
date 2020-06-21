using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using winapp.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using winapp;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages.LogIn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CompanySelectionPage : Page
    {
        public CompanySelectionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            long fieldID = (long)e.Parameter;
            companiesTable.SelectWhereFieldID(fieldID);
            App.workObjects.companiesTable = companiesTable;
        }

        private void CompanySelectionListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CompanySelectionListView.SelectedItem == null) return;
            LogInAsync(((Companies)(CompanySelectionListView.SelectedItem)).lID);
        }

        private async void LogInAsync(long ID)
        {
            LogInDialog logInDialog = new LogInDialog();
            await logInDialog.ShowAsync();
            if (logInDialog.Result == SignInResult.SignInOK)
            {
                App.userLoggedIn = true;
                App.userCompanyID = ID;
                App.workObjects.loadProjects();
                App.workObjects.loadAccounts();
                App.workObjects.loadTransactions();
                MainPage.parentFrame.Navigate(typeof(MainPage));
            }
        }

        private CCompaniesTable companiesTable = new CCompaniesTable();
    }
}
