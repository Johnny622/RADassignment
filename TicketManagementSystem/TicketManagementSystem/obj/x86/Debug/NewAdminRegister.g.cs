﻿#pragma checksum "C:\Users\EDT\Desktop\New folder (2)\RADassignment\TicketManagementSystem\TicketManagementSystem\NewAdminRegister.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F0D0BD73EDB5398F50ED88FF2DD8FB90C180F008BFF7E62B7F96421B623B3564"
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
    partial class NewAdminRegister : 
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
            case 2: // NewAdminRegister.xaml line 30
                {
                    this.BackBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackBtn).Click += this.BackBtn_Click;
                }
                break;
            case 3: // NewAdminRegister.xaml line 97
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // NewAdminRegister.xaml line 98
                {
                    this.SignUpSubmitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SignUpSubmitBtn).Click += this.SignUpSubmitBtn_Click;
                }
                break;
            case 5: // NewAdminRegister.xaml line 46
                {
                    this.SignUpEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // NewAdminRegister.xaml line 52
                {
                    this.SignUpPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // NewAdminRegister.xaml line 58
                {
                    this.SignUpContact = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // NewAdminRegister.xaml line 64
                {
                    this.SignUpFullName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // NewAdminRegister.xaml line 70
                {
                    this.SignUpMyKad = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // NewAdminRegister.xaml line 76
                {
                    this.SignUpGender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 11: // NewAdminRegister.xaml line 78
                {
                    this.Male = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 12: // NewAdminRegister.xaml line 79
                {
                    this.Female = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
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

