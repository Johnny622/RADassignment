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

                //TextBlock label = new TextBlock
                //{
                //    Text = "Name",
                //    HorizontalAlignment = HorizontalAlignment.Center
                //};
                StackPanel stackPanel_vertical1 = new StackPanel();
                stackPanel_vertical1.Children.Add(new TextBlock { Text = "Passenger (" + (i + 1) + "/" + numOfPax + ")" });
                StackPanel stackPanel_horizontal = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                for (int j = 0; j < labels.Length; j++)
                {
                    TextBlock label = createLabel(labels[j]);
                    StackPanel stackPanel_vertical = new StackPanel();
                    stackPanel_vertical.Children.Add(label);

                    if (j == 0)
                    {
                        TextBox tb = new TextBox();
                        stackPanel_vertical.Children.Add(tb);
                    }
                    else if(j == 1)
                    {
                        ComboBox cbx = createComboBox();
                        stackPanel_vertical.Children.Add(cbx);
                    }

                    stackPanel_horizontal.Children.Add(stackPanel_vertical);
                }

                stackPanel_vertical1.Children.Add(stackPanel_horizontal);

                Grid.SetColumn(stackPanel_vertical1, 0);
                Grid.SetRow(stackPanel_vertical1, i);

                mainGrid.Children.Add(stackPanel_vertical1);
            }
        }

        private TextBlock createLabel(string name)
        {
            TextBlock label = new TextBlock 
            {
                Text = name
            };
            return label;
        }
        private ComboBox createComboBox()
        {
            ComboBox comboBox = new ComboBox();
            ComboBoxItem item1 = new ComboBoxItem();
            ComboBoxItem item2 = new ComboBoxItem();

            item1.Content = "Female";
            item2.Content = "Male";
            comboBox.Items.Add(item1);
            comboBox.Items.Add(item2);

            return comboBox;
        }
    }
}
