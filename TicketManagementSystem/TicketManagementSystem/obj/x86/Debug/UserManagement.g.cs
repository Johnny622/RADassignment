﻿#pragma checksum "C:\Users\Lau Tin Tin\Desktop\RAD Clone New\RADassignment\TicketManagementSystem\TicketManagementSystem\UserManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "138355077BBA5E401B642A8542A1D282B8CE1582BFB2D97A14401E6EBDA65FE8"
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
    partial class UserManagement : 
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
            case 2: // UserManagement.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // UserManagement.xaml line 51
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UserManagement.xaml line 56
                {
                    this.userProfile = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // UserManagement.xaml line 57
                {
                    this.WelcomeMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // UserManagement.xaml line 59
                {
                    this.MyProfileBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MyProfileBtn).Click += this.MyProfileBtn_Click;
                }
                break;
            case 7: // UserManagement.xaml line 61
                {
                    this.ChangePwBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ChangePwBtn).Click += this.ChangePwBtn_Click;
                }
                break;
            case 8: // UserManagement.xaml line 63
                {
                    this.DeleteAccBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DeleteAccBtn).Click += this.DeleteAccBtn_Click;
                }
                break;
            case 9: // UserManagement.xaml line 65
                {
                    this.LogoutBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LogoutBtn).Click += this.LogoutBtn_Click;
                }
                break;
            case 10: // UserManagement.xaml line 21
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 11: // UserManagement.xaml line 28
                {
                    this.btnTrainMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnTrainMng).Click += this.btnTrainMng_Click;
                }
                break;
            case 12: // UserManagement.xaml line 16
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

