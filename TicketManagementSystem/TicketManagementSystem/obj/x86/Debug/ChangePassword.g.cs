﻿#pragma checksum "C:\Users\Lau Tin Tin\Desktop\RAD Clone New\RADassignment\TicketManagementSystem\TicketManagementSystem\ChangePassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E8C1C2AB415BF7963AA193E4AE7BC4EA2B1DE4554F1DB651CCA1D26071D53F3A"
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
    partial class ChangePassword : 
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
            case 2: // ChangePassword.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // ChangePassword.xaml line 51
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // ChangePassword.xaml line 57
                {
                    this.CurPw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5: // ChangePassword.xaml line 59
                {
                    this.NewPw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // ChangePassword.xaml line 61
                {
                    this.ConfPw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // ChangePassword.xaml line 62
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // ChangePassword.xaml line 63
                {
                    this.SubmitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SubmitBtn).Click += this.SubmitBtn_Click;
                }
                break;
            case 9: // ChangePassword.xaml line 21
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUserMng).Click += this.btnUserMng_Click;
                }
                break;
            case 10: // ChangePassword.xaml line 28
                {
                    this.btnTrainMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnTrainMng).Click += this.btnTrainMng_Click;
                }
                break;
            case 11: // ChangePassword.xaml line 16
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

