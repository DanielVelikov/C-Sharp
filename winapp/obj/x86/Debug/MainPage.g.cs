﻿#pragma checksum "C:\Users\d_ger\source\repos\winapp\winapp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5F307D4EC515F3F4B6EC23DFA83978FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace winapp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 71
                {
                    this.MainPageSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2: // MainPage.xaml line 79
                {
                    this.MainPageListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.MainPageListBox).SelectionChanged += this.MainPageListBox_SelectionChanged;
                }
                break;
            case 3: // MainPage.xaml line 82
                {
                    this.HomeNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 4: // MainPage.xaml line 93
                {
                    this.CompanyNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 5: // MainPage.xaml line 104
                {
                    this.ProjectsManagementNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 6: // MainPage.xaml line 115
                {
                    this.AccountingManagementNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 7: // MainPage.xaml line 128
                {
                    this.ProjectOverrviewNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 8: // MainPage.xaml line 141
                {
                    this.AccountingOverrviewNavItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 9: // MainPage.xaml line 157
                {
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 10: // MainPage.xaml line 16
                {
                    this.MainPageNavButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MainPageNavButton).Click += this.MainPageNavButton_Click;
                }
                break;
            case 11: // MainPage.xaml line 26
                {
                    this.SearchBox = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                }
                break;
            case 12: // MainPage.xaml line 34
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                }
                break;
            case 13: // MainPage.xaml line 43
                {
                    this.HomeButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.HomeButton).Click += this.HomeButton_Click;
                }
                break;
            case 14: // MainPage.xaml line 52
                {
                    this.ForwardButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ForwardButton).Click += this.ForwardButton_Click;
                }
                break;
            case 15: // MainPage.xaml line 61
                {
                    this.ExitButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ExitButton).Click += this.ExitButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

