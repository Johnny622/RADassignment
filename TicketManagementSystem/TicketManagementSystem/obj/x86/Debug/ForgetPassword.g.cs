﻿#pragma checksum "C:\Users\EDT\Desktop\New folder (2)\RADassignment\TicketManagementSystem\TicketManagementSystem\ForgetPassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3BDCC757C4E4D88818085CC8B11E13A12F13F1072E0F76143C42883952FA1A24"
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
    partial class ForgetPassword : 
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
            case 2: // ForgetPassword.xaml line 29
                {
                    this.BackBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackBtn).Click += this.BackBtn_Click;
                }
                break;
            case 3: // ForgetPassword.xaml line 40
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // ForgetPassword.xaml line 42
                {
                    this.UserVerified = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.UserVerified).Click += this.UserVerified_Click;
                }
                break;
            case 5: // ForgetPassword.xaml line 47
                {
                    this.NewPwLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // ForgetPassword.xaml line 48
                {
                    this.NewPwTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // ForgetPassword.xaml line 49
                {
                    this.BackToLoginPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackToLoginPage).Click += this.BackBtn_Click;
                }
                break;
            case 8: // ForgetPassword.xaml line 36
                {
                    this.VerifiedEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // ForgetPassword.xaml line 38
                {
                    this.VerifiedPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

