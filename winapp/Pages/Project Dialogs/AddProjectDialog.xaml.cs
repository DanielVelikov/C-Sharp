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

namespace winapp.Pages.Project_Dialogs
{
    public sealed partial class AddProjectDialog : ContentDialog
    {
        public AddProjectDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            long projectSize = ((ProjectSizes)(ProjectSizeComboBox.SelectedItem)).lID;
            DateTime StartDate = Convert.ToDateTime(StartDateControl.Date.ToString());
            DateTime EndDate = Convert.ToDateTime(EndDateControl.Date.ToString());
            Projects newProject = new Projects(0, 0, ProjectNameTextBox.Text, (int)App.userCompanyID, (int)projectSize, StartDate, EndDate);
            App.workObjects.projectsTable.InsertRecord(newProject);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private CProjectSizesTable projectSizesTable = App.workObjects.projectSizesTable;
    }
}
