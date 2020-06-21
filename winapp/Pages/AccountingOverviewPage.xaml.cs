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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountingOverviewPage : Page
    {
        public AccountingOverviewPage()
        {
            this.InitializeComponent();
        }

        private void AccountingManagementButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.navigarionListBox.SelectedIndex = 3;
            MainPage.MainPageFrame.Navigate(typeof(AccountingManagementPage));
        }

        private void ProjectsOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.navigarionListBox.SelectedIndex = 4;
            MainPage.MainPageFrame.Navigate(typeof(ProjectOverrviewPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = transactionCharts.transactionsTypeCharts;
            (LineChart.Series[0] as LineSeries).ItemsSource = transactionCharts.transactionsAccountCharts;
            (PieChart.Series[0] as PieSeries).ItemsSource = transactionCharts.transactionsProjectCharts;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.navigarionListBox.SelectedIndex = 5;
        }

        CTransactionCharts transactionCharts = new CTransactionCharts();
    }
}
