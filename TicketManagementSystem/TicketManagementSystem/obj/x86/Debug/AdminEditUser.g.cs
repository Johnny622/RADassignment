﻿#pragma checksum "C:\Users\EDT\Desktop\Test\RADassignment\TicketManagementSystem\TicketManagementSystem\AdminEditUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A5CA6AA63AB1871CDDBC0F71058068E347A8DEB0F4922E1ED4E47194C889DC51"
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
    partial class AdminEditUser : 
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
            case 2: // AdminEditUser.xaml line 13
                {
                    this.backBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.backBtn).Click += this.backBtn_Click;
                }
                break;
            case 3: // AdminEditUser.xaml line 17
                {
                    this.UserName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // AdminEditUser.xaml line 19
                {
                    this.UserEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // AdminEditUser.xaml line 21
                {
                    this.UserIC = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // AdminEditUser.xaml line 23
                {
                    this.UserPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // AdminEditUser.xaml line 25
                {
                    this.UserGender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8: // AdminEditUser.xaml line 30
                {
                    this.SubmitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SubmitBtn).Click += this.SubmitBtn_Click;
                }
                break;
            case 9: // AdminEditUser.xaml line 27
                {
                    this.Male = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 10: // AdminEditUser.xaml line 28
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

