﻿#pragma checksum "C:\Users\ACER\Desktop\Y2S3\--Clone Resposity--\RADassignment\TicketManagementSystem\TicketManagementSystem\UserManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "01F7CC3145057D7FD91024C4F6CCE17D53793E50C473EA1D67FABD2DF61014BB"
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
            case 3: // UserManagement.xaml line 58
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UserManagement.xaml line 63
                {
                    this.userProfile = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // UserManagement.xaml line 64
                {
                    this.WelcomeMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // UserManagement.xaml line 66
                {
                    this.MyProfileBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MyProfileBtn).Click += this.MyProfileBtn_Click;
                }
                break;
            case 7: // UserManagement.xaml line 68
                {
                    this.ChangePwBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ChangePwBtn).Click += this.ChangePwBtn_Click;
                }
                break;
            case 8: // UserManagement.xaml line 70
                {
                    this.DeleteAccBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DeleteAccBtn).Click += this.DeleteAccBtn_Click;
                }
                break;
            case 9: // UserManagement.xaml line 72
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
            case 12: // UserManagement.xaml line 49
                {
                    this.btnHelp = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHelp).Click += this.btnHelp_Click;
                }
                break;
            case 13: // UserManagement.xaml line 16
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

