﻿#pragma checksum "C:\Users\thiva\source\repos\Johnny622\RADassignment\TicketManagementSystem\TicketManagementSystem\TrainManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E62D08EFD4E356ECA251B76D9C24AE77E45EDD82E5AA6E0526184B8AE5EFFF86"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketManagementSystem
{
    partial class TrainManagement : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // TrainManagement.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // TrainManagement.xaml line 52
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // TrainManagement.xaml line 57
                {
                    this.trainroute = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // TrainManagement.xaml line 58
                {
                    this.WelcomeMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // TrainManagement.xaml line 60
                {
                    this.addRoute = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.addRoute).Click += this.addRoutebtn_Click;
                }
                break;
            case 7: // TrainManagement.xaml line 62
                {
                    this.deleteRoute = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.deleteRoute).Click += this.deleteRoutebtn_Click;
                }
                break;
            case 8: // TrainManagement.xaml line 64
                {
                    this.viewRoute = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.viewRoute).Click += this.viewRoutebtn_Click;
                }
                break;
            case 9: // TrainManagement.xaml line 21
                {
                    this.btnAdminMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdminMng).Click += this.btnAdminMng_Click;
                }
                break;
            case 10: // TrainManagement.xaml line 28
                {
                    this.btnTrainMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 11: // TrainManagement.xaml line 35
                {
                    this.btnViewUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnViewUser).Click += this.btnViewUser_Click;
                }
                break;
            case 12: // TrainManagement.xaml line 42
                {
                    this.btnHelp = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHelp).Click += this.btnHelp_Click;
                }
                break;
            case 13: // TrainManagement.xaml line 16
                {
                    this.btnBar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBar).Click += this.btnBar_Click;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

