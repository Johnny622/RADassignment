<<<<<<< HEAD
﻿#pragma checksum "C:\Users\EDT\Desktop\New folder (2)\RADassignment\TicketManagementSystem\TicketManagementSystem\DisplayRoute.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D6A44C9E4D1FF3C8F5933CAB6E1C3B6060284DE4508BB4858252E1B86618EE6"
=======
﻿#pragma checksum "C:\Users\thiva\OneDrive\Documents\GitHub\RADassignment\RADassignment\TicketManagementSystem\TicketManagementSystem\DisplayRoute.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D6A44C9E4D1FF3C8F5933CAB6E1C3B6060284DE4508BB4858252E1B86618EE6"
>>>>>>> 783e83d3132e788faae02af37ee968233c1c0037
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
    partial class DisplayRoute : 
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
            case 2: // DisplayRoute.xaml line 13
                {
                    this.rightContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // DisplayRoute.xaml line 14
                {
                    this.backBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.backBtn).Click += this.backBtn_Click;
                }
                break;
            case 4: // DisplayRoute.xaml line 26
                {
                    this.trainDetailsContainer = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // DisplayRoute.xaml line 20
                {
                    this.origin = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6: // DisplayRoute.xaml line 22
                {
                    this.destination = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
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

