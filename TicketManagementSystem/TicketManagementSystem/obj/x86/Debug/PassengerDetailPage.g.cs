﻿#pragma checksum "C:\Users\Lau Tin Tin\Desktop\RAD Clone New\RADassignment\TicketManagementSystem\TicketManagementSystem\PassengerDetailPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A1E2B387C149E3B230049B5B6F92594440EDE5AA3DF36BC3B9E964DF3FB16D7"
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
    partial class PassengerDetailPage : 
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
            case 2: // PassengerDetailPage.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // PassengerDetailPage.xaml line 52
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // PassengerDetailPage.xaml line 54
                {
                    this.displayError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // PassengerDetailPage.xaml line 59
                {
                    this.btnConfirm = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnConfirm).Click += this.btnConfirm_Click;
                }
                break;
            case 6: // PassengerDetailPage.xaml line 56
                {
                    this.mainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // PassengerDetailPage.xaml line 21
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUserMng).Click += this.btnUserMng_Click;
                }
                break;
            case 8: // PassengerDetailPage.xaml line 35
                {
                    this.btnBookingPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBookingPage).Click += this.btnBookingPage_Click;
                }
                break;
            case 9: // PassengerDetailPage.xaml line 16
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

