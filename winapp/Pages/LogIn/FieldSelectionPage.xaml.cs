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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace winapp.Pages.LogIn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FieldSelectionPage : Page
    {
        public FieldSelectionPage()
        {
            this.InitializeComponent();
        }

        private void FieldsItemGridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FieldsItemGridView.SelectedItem == null) return;
            if (App.userLoggedIn)
            {
                lofOfAsync();
            }
            long selectedItemID = ((Fields)(FieldsItemGridView.SelectedItem)).lID;
            LogInFrame.Navigate(typeof(CompanySelectionPage), selectedItemID);
        }

        private async void lofOfAsync()
        {
            LogOfDialog logOf = new LogOfDialog();
            await logOf.ShowAsync();
        }

        private CFieldsTable fieldTable = new CFieldsTable();
    }
}
