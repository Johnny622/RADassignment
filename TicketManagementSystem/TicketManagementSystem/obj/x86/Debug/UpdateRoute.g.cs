﻿#pragma checksum "C:\Users\Lau Tin Tin\Desktop\RAD Clone New\RADassignment\TicketManagementSystem\TicketManagementSystem\UpdateRoute.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F48836F355BBFB357123565B7D4D9A80726C1712B2881EF57B376EC0D610FB7F"
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
    partial class UpdateRoute : 
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
            case 2: // UpdateRoute.xaml line 12
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // UpdateRoute.xaml line 16
                {
                    this.border1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UpdateRoute.xaml line 20
                {
                    this.origin = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // UpdateRoute.xaml line 21
                {
                    this.destination = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // UpdateRoute.xaml line 50
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // UpdateRoute.xaml line 36
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnUpdate_Click;
                }
                break;
            case 8: // UpdateRoute.xaml line 43
                {
                    this.btnBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBack).Click += this.btnBack_Click;
                }
                break;
            case 9: // UpdateRoute.xaml line 25
                {
                    this.trainID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // UpdateRoute.xaml line 27
                {
                    this.price = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // UpdateRoute.xaml line 29
                {
                    this.availableseat = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

