﻿#pragma checksum "C:\Users\EDT\Documents\Y2S3\Rapid\New folder\RADassignment\TicketManagementSystem\TicketManagementSystem\TrainManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "593A3E0C94AA32A5D1E8FB6BAA90B38EB104B857475E0C4F08D63B32A7AC8891"
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
    partial class TrainManagement : 
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
            case 2: // TrainManagement.xaml line 13
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // TrainManagement.xaml line 40
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // TrainManagement.xaml line 43
                {
                    this.border1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // TrainManagement.xaml line 47
                {
                    this.origin = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // TrainManagement.xaml line 48
                {
                    this.destination = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // TrainManagement.xaml line 88
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // TrainManagement.xaml line 75
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnAdd_Click;
                }
                break;
            case 9: // TrainManagement.xaml line 81
                {
                    this.btnBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBack).Click += this.btnBack_Click;
                }
                break;
            case 10: // TrainManagement.xaml line 69
                {
                    this.arrivaldate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 11: // TrainManagement.xaml line 71
                {
                    this.arrivaltime = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 12: // TrainManagement.xaml line 61
                {
                    this.departdate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 13: // TrainManagement.xaml line 63
                {
                    this.departtime = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 14: // TrainManagement.xaml line 51
                {
                    this.trainID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // TrainManagement.xaml line 53
                {
                    this.price = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // TrainManagement.xaml line 55
                {
                    this.availableseat = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // TrainManagement.xaml line 22
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUserMng).Click += this.btnUserMng_Click;
                }
                break;
            case 18: // TrainManagement.xaml line 17
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

