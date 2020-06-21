using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using winapp.Classes;
using winapp.Pages.Project_Dialogs;
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
    public sealed partial class ProjectManagementPage : Page
    {
        public ProjectManagementPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.navigarionListBox.SelectedIndex = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectManagementPage));
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddProjectDialog addProjectDialog = new AddProjectDialog();
            addProjectDialog.ShowAsync();
        }

        private void UpdateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectmanagementListView.SelectedItem == null) return;

            string projectName = ((Projects)ProjectmanagementListView.SelectedItem).szName;
            DateTime startDate = ((Projects)ProjectmanagementListView.SelectedItem).StartDate;
            DateTime endDate = ((Projects)ProjectmanagementListView.SelectedItem).EndDate;
            long projectSizeID = ((Projects)ProjectmanagementListView.SelectedItem).lProjectSizeID;
            long ID = ((Projects)ProjectmanagementListView.SelectedItem).lID;
            long updateCounter = ((Projects)ProjectmanagementListView.SelectedItem).lUpdateCounter;

            Projects project = new Projects((int)ID, (int)updateCounter, projectName, (int)App.userCompanyID, (int)projectSizeID, startDate, endDate);
            UpdateProjectDialog updateProjectDialog = new UpdateProjectDialog(project);

            updateProjectDialog.ShowAsync();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            App.workObjects.projectsTable.RefreshData();
        }


        private CProjectsTable projectsTable = App.workObjects.projectsTable;
    }
}
