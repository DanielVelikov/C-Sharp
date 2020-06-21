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
    public sealed partial class ProjectOverrviewPage : Page
    {
        public ProjectOverrviewPage()
        {
            this.InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            (PieChart.Series[0] as PieSeries).ItemsSource = projectChartLists.projectSizesCharts;
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = projectChartLists.projectDeadlineCharts;
        }

        private void ProjectsManagementButtton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.navigarionListBox.SelectedIndex = 2;
            MainPage.MainPageFrame.Navigate(typeof(ProjectManagementPage));
        }

        private void AccountingOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.navigarionListBox.SelectedIndex = 5;
            MainPage.MainPageFrame.Navigate(typeof(AccountingOverviewPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.navigarionListBox.SelectedIndex = 4;
        }
        private CProjectCharts projectChartLists = new CProjectCharts();
    }
}
