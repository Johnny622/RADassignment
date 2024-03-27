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
    public sealed partial class PassengerDetailPage : Page
    {
        public PassengerDetailPage()
        {
            this.InitializeComponent();
            generatePassengerDetail(20);
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            menuSplitView.IsPaneOpen = !menuSplitView.IsPaneOpen;
            if (menuSplitView.IsPaneOpen == true)
            {
                rightContent.Margin = new Thickness(270, 0, 0, 0);
            }
            else
            {
                rightContent.Margin = new Thickness(80, 0, 0, 0);
            }
        }

        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {

        }
        private void generatePassengerDetail(int numOfPax)
        {
            String[] labels = {"Name", "Gender", "Phone", "I/C"};

            for (int i = 0; i < numOfPax; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                mainGrid.ColumnDefinitions[0].Width = new GridLength(800, GridUnitType.Pixel);
                mainGrid.RowDefinitions.Add(new RowDefinition());

                TextBlock label = new TextBlock
                {
                    Text = "Name",
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                TextBox tb = new TextBox();

                StackPanel stackPanel_vertical = new StackPanel();
                StackPanel stackPanel_horizontal = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                stackPanel_vertical.Children.Add(new TextBlock { Text = "Passenger (" + (i + 1) + "/" + numOfPax + ")"});
                stackPanel_vertical.Children.Add(label);
                stackPanel_vertical.Children.Add(tb);

                stackPanel_horizontal.Children.Add(stackPanel_vertical);

                Grid.SetColumn(stackPanel_horizontal, 0);
                Grid.SetRow(stackPanel_horizontal, i);

                mainGrid.Children.Add(stackPanel_horizontal);
            }
        }

        private void createLabel(string name)
        {
            TextBlock label = new TextBlock 
            {
                Text = name
            };
        }
    }
}
