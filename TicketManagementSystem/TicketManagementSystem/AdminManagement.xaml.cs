using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminManagement : Page
    {
        public AdminManagement()
        {
            this.InitializeComponent();
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePwBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAccBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void AddTrainRoute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewAdminRegister));
        }

        private void ViewUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
