<<<<<<< Updated upstream
<<<<<<< HEAD
﻿#pragma checksum "C:\Users\Janet\Desktop\RADassignment\TicketManagementSystem\TicketManagementSystem\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "893BF024C15CB3D62456734A6D5BC43FAD673377EB230E1FD4FE43B1FDEDEB89"
=======
﻿#pragma checksum "C:\Users\ACER\Desktop\Y2S3\--Clone Resposity--\RADassignment\TicketManagementSystem\TicketManagementSystem\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "893BF024C15CB3D62456734A6D5BC43FAD673377EB230E1FD4FE43B1FDEDEB89"
>>>>>>> f4e4161b6fa576a8ee6207727c59b2e3d7d81af7
=======
﻿#pragma checksum "C:\Users\thiva\source\repos\Johnny622\RADassignment\TicketManagementSystem\TicketManagementSystem\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "893BF024C15CB3D62456734A6D5BC43FAD673377EB230E1FD4FE43B1FDEDEB89"
>>>>>>> Stashed changes
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
    partial class LoginPage : 
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
            case 2: // LoginPage.xaml line 62
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // LoginPage.xaml line 63
                {
                    this.ForgetPw = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.ForgetPw).Click += this.ForgetPw_Click;
                }
                break;
            case 4: // LoginPage.xaml line 64
                {
                    this.LoginBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LoginBtn).Click += this.LoginBtn_Click;
                }
                break;
            case 5: // LoginPage.xaml line 70
                {
                    this.SignUpNew = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.SignUpNew).Click += this.SignUpNew_Click;
                }
                break;
            case 6: // LoginPage.xaml line 60
                {
                    this.PasswordTextBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                    ((global::Windows.UI.Xaml.Controls.PasswordBox)this.PasswordTextBox).KeyDown += this.LoginEnter_KeyDown;
                }
                break;
            case 7: // LoginPage.xaml line 55
                {
                    this.EmailTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.EmailTextBox).KeyDown += this.LoginUserNameEnter_KeyDown;
                }
                break;
            case 8: // LoginPage.xaml line 35
                {
                    this.LoginBtnUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LoginBtnUser).Click += this.LoginBtnUser_Click;
                    ((global::Windows.UI.Xaml.Controls.Button)this.LoginBtnUser).KeyDown += this.LoginEnter_KeyDown;
                }
                break;
            case 9: // LoginPage.xaml line 43
                {
                    this.LoginBtnAdmin = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LoginBtnAdmin).Click += this.LoginBtnAdmin_Click;
                    ((global::Windows.UI.Xaml.Controls.Button)this.LoginBtnAdmin).KeyDown += this.LoginEnter_KeyDown;
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

