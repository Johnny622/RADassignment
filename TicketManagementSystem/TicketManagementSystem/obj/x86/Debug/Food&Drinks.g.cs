﻿#pragma checksum "C:\Users\thiva\source\repos\Johnny622\RADassignment\TicketManagementSystem\TicketManagementSystem\Food&Drinks.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EAB133C2FAD18AD4C326392A50D0985484BC77E6CFEE97D452129B467A08968C"
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
    partial class Food_Drinks : 
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
            case 2: // Food&Drinks.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // Food&Drinks.xaml line 94
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // Food&Drinks.xaml line 91
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.ConfirmPayment_Click;
                }
                break;
            case 5: // Food&Drinks.xaml line 87
                {
                    this.totalPriceTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Food&Drinks.xaml line 80
                {
                    this.quantityTextBox2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.quantityTextBox2).TextChanged += this.QuantityTextBox_TextChanged;
                }
                break;
            case 7: // Food&Drinks.xaml line 68
                {
                    this.quantityTextBox1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.quantityTextBox1).TextChanged += this.QuantityTextBox_TextChanged;
                }
                break;
            case 8: // Food&Drinks.xaml line 21
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUserMng).Click += this.btnUserMng_Click;
                }
                break;
            case 9: // Food&Drinks.xaml line 35
                {
                    this.btnBookingPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBookingPage).Click += this.btnBookingPage_Click;
                }
                break;
            case 10: // Food&Drinks.xaml line 49
                {
                    this.btnHelp = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHelp).Click += this.btnHelp_Click;
                }
                break;
            case 11: // Food&Drinks.xaml line 16
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
