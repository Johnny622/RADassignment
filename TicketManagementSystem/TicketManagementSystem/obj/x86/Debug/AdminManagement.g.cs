﻿#pragma checksum "C:\Users\ACER\Desktop\Y2S3\--Clone Resposity--\RADassignment\TicketManagementSystem\TicketManagementSystem\AdminManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4879F1BE223639EE6F60F96F63D75D86D93BD9548278F0624C4CD7F3157BDB54"
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
    partial class AdminManagement : 
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
            case 2: // AdminManagement.xaml line 13
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // AdminManagement.xaml line 52
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // AdminManagement.xaml line 57
                {
                    this.WelcomeMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // AdminManagement.xaml line 59
                {
                    this.MyProfileBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MyProfileBtn).Click += this.MyProfileBtn_Click;
                }
                break;
            case 6: // AdminManagement.xaml line 61
                {
                    this.ChangePwBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ChangePwBtn).Click += this.ChangePwBtn_Click;
                }
                break;
            case 7: // AdminManagement.xaml line 63
                {
                    this.AddAdminBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddAdminBtn).Click += this.AddAdminBtn_Click;
                }
                break;
            case 8: // AdminManagement.xaml line 65
                {
                    this.DeleteAccBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DeleteAccBtn).Click += this.DeleteAccBtn_Click;
                }
                break;
            case 9: // AdminManagement.xaml line 67
                {
                    this.LogoutBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LogoutBtn).Click += this.LogoutBtn_Click;
                }
                break;
            case 10: // AdminManagement.xaml line 22
                {
                    this.btnAdminMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 11: // AdminManagement.xaml line 29
                {
                    this.btnTrainMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnTrainMng).Click += this.btnTrainMng_Click;
                }
                break;
            case 12: // AdminManagement.xaml line 36
                {
                    this.btnViewUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnViewUser).Click += this.btnViewUser_Click;
                }
                break;
            case 13: // AdminManagement.xaml line 17
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

