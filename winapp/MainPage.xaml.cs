using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using winapp.Pages;
using winapp.Pages.LogIn;
using Windows.UI.ViewManagement;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace winapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Frame MainPageFrame;
        public static Frame parentFrame;
        public static ListBox navigarionListBox;
        public MainPage()
        {  
            this.InitializeComponent();
            MainPageFrame = MainFrame;
            navigarionListBox = MainPageListBox;
            parentFrame = Window.Current.Content as Frame;
        }

        private void MainPageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           switch(MainPageListBox.SelectedIndex)
            {
                case 0:
                    {
                       MainPageFrame.Navigate(typeof(FieldSelectionPage));
                       break;
                    }
                case 1:
                    {
                        MainPageFrame.Navigate(typeof(CompanyPage));
                        break;
                    }
                case 2:
                    {
                        MainPageFrame.Navigate(typeof(ProjectManagementPage));
                        break;
                    }
                case 3:
                    {
                        MainPageFrame.Navigate(typeof(AccountingManagementPage));
                        break;
                    }
                case 4:
                    {
                        MainPageFrame.Navigate(typeof(ProjectOverrviewPage));
                        break;
                    }
                case 5:
                    {
                        MainPageFrame.Navigate(typeof(AccountingOverviewPage));
                        break;
                    }
            }
        }

        private void MainPageNavButton_Click(object sender, RoutedEventArgs e)
        {
            MainPageSplitView.IsPaneOpen = !MainPageSplitView.IsPaneOpen;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ListBoxItemControl();
        }

        private void ListBoxItemControl()
        {
            if (App.userLoggedIn)
            {
                foreach (ListBoxItem item in MainPageListBox.Items)
                {
                    item.IsEnabled = true;
                }
                navigarionListBox.SelectedIndex = 1;
                MainFrame.Navigate(typeof(CompanyPage));
            }
            else
            {
                foreach (ListBoxItem item in MainPageListBox.Items)
                {
                    item.IsEnabled = false;
                }
                MainFrame.Navigate(typeof(FieldSelectionPage));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageFrame.CanGoBack) MainPageFrame.GoBack();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageFrame.CanGoForward) MainPageFrame.GoForward();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainPageFrame.Navigate(typeof(FieldSelectionPage));
        }
    }
}
