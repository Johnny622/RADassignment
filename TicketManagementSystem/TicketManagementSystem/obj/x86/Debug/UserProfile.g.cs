<<<<<<< HEAD
﻿#pragma checksum "C:\Users\EDT\Documents\Y2S3\New folder\RADassignment\TicketManagementSystem\TicketManagementSystem\UserProfile.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28DEBF3D687C5C3186BA51509FF6305E5DDCE2A0237313DD863A85771478B450"
=======
﻿#pragma checksum "C:\Users\Lau Tin Tin\Desktop\RAD Transport\RADassignment\TicketManagementSystem\TicketManagementSystem\UserProfile.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0F55721D49E1159F3933031AF8D1B7FE8FBFAD11BBBFF5A5D2BB34C31F7984D"
>>>>>>> 992004294fb57d8f29d831de973215776a4360eb
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
    partial class UserProfile : 
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
            case 2: // UserProfile.xaml line 12
                {
                    this.menuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // UserProfile.xaml line 51
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UserProfile.xaml line 56
                {
                    this.UserName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // UserProfile.xaml line 57
                {
                    this.UserEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // UserProfile.xaml line 58
                {
                    this.UserID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // UserProfile.xaml line 59
                {
                    this.UserIC = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // UserProfile.xaml line 60
                {
                    this.UserPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // UserProfile.xaml line 61
                {
                    this.UserGender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10: // UserProfile.xaml line 66
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // UserProfile.xaml line 67
                {
                    this.SubmitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SubmitBtn).Click += this.SubmitBtn_Click;
                }
                break;
            case 12: // UserProfile.xaml line 63
                {
                    this.Male = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 13: // UserProfile.xaml line 64
                {
                    this.Female = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 14: // UserProfile.xaml line 21
                {
                    this.btnUserMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUserMng).Click += this.btnUserMng_Click;
                }
                break;
            case 15: // UserProfile.xaml line 28
                {
                    this.btnTrainMng = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnTrainMng).Click += this.btnTrainMng_Click;
                }
                break;
            case 16: // UserProfile.xaml line 16
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

