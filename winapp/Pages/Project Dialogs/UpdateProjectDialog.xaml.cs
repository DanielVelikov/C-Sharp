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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages.Project_Dialogs
{
    public sealed partial class UpdateProjectDialog : ContentDialog
    {

        public UpdateProjectDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            pr.szName = ProjectNameTextBox.Text;
            pr.lProjectSizeID = ((ProjectSizes)(ProjectSizeComboBox.SelectedItem)).lID;
            pr.StartDate = Convert.ToDateTime(StartDateControl.Date.ToString());
            pr.EndDate = Convert.ToDateTime(EndDateControl.Date.ToString());
            App.workObjects.projectsTable.UpdateWhereID(pr.lID, pr);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        internal UpdateProjectDialog(Projects project)
        {
            this.InitializeComponent();
            pr = project;
        }

        internal void setData()
        {
            ProjectNameTextBox.Text = pr.getName();
            StartDateControl.Date = pr.StartDate.Date;
            EndDateControl.Date = pr.EndDate.Date;
            ProjectSizeComboBox.SelectedValue = projectSizesTable.ProjectSizesList.Where(x => x.lID.Equals(pr.lProjectSizeID)).First();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            this.setData();
        }

        private Projects pr;
        private CProjectSizesTable projectSizesTable = App.workObjects.projectSizesTable;

    }
}
