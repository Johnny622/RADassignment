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
using TicketManagementSystem.Class;
using Windows.UI.Xaml.Documents;
using Windows.UI.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PassengerDetailPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public PassengerDetailPage()
        {
            this.InitializeComponent();
            generatePassengerDetail(ListStaticData.noOfPax);
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
            String[] labels = { "Name", "Gender", "Phone", "I/C" };

            for (int i = 0; i < numOfPax; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                mainGrid.ColumnDefinitions[0].Width = new GridLength(800, GridUnitType.Pixel);
                mainGrid.RowDefinitions.Add(new RowDefinition());

                StackPanel stackPanel_vertical1 = new StackPanel();
                stackPanel_vertical1.Children.Add(new TextBlock 
                {
                    Text = "Passenger (" + (i + 1) + "/" + numOfPax + ")",
                    FontWeight = FontWeights.Bold
                });
                StackPanel stackPanel_horizontal = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                for (int j = 0; j < labels.Length; j++)
                {
                    TextBlock label = createLabel(labels[j]);
                    StackPanel stackPanel_vertical = new StackPanel();
                    stackPanel_vertical.Margin = new Thickness(5);
                    stackPanel_vertical.Children.Add(label);

                    if (j == 0)
                    {
                        TextBox tb = new TextBox {
                            Width = 200
                        };
                        stackPanel_vertical.Children.Add(tb);
                    }
                    else if (j == 1)
                    {
                        ComboBox cbx = createComboBox();
                        stackPanel_vertical.Children.Add(cbx);
                    }
                    else if (j == 2)
                    {
                        TextBox tb = new TextBox 
                        {
                            Width = 150
                        };
                        tb.InputScope = new InputScope()
                        {
                            Names = { new InputScopeName() { NameValue = InputScopeNameValue.TelephoneNumber } }
                        };
                        stackPanel_vertical.Children.Add(tb);
                    }
                    else
                    {
                        TextBox tbIC = new TextBox();
                        tbIC.PlaceholderText = "000000-00-0000";
                        tbIC.InputScope = new InputScope()
                        {
                            Names = { new InputScopeName() { NameValue = InputScopeNameValue.Number } }
                        };
                        tbIC.KeyUp += TbIC_KeyUp;
                        stackPanel_vertical.Children.Add(tbIC);
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
                Text = name,
                FontWeight = FontWeights.Bold
            };
            return label;
        }
        private ComboBox createComboBox()
        {
            ComboBox comboBox = new ComboBox()
            {
                Name = "cbxGender",
                Width = 100
            };
            ComboBoxItem item1 = new ComboBoxItem();
            ComboBoxItem item2 = new ComboBoxItem();

            item1.Content = "Female";
            item2.Content = "Male";
            comboBox.Items.Add(item1);
            comboBox.Items.Add(item2);
            comboBox.SelectedIndex = 0;

            return comboBox;
        }

        private void TbIC_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TextBox textBox = sender as TextBox;
                string text = textBox.Text;

                if (text.Length == 14 && text.Substring(6, 1) == "-" && text.Substring(9, 1) == "-")
                {
                    displayError.Visibility = Visibility.Collapsed;
                }
                else
                {
                    displayError.Text = "Please enter IC number in correct format. e.g.001123-08-9092";
                    displayError.Visibility = Visibility.Visible;
                }
            }
        }

        private async void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<PassengerDetails> passengerDetailsList = new List<PassengerDetails>();

            foreach (var child in mainGrid.Children)
            {
                if (child is StackPanel stackPanel)
                {
                    string name = "";
                    string gender = "";
                    string phone = "";
                    string ic = "";
                    string labelText = "";
                    var secondChild = stackPanel.Children[1];

                    if (secondChild is StackPanel horizontalSPDetails)
                    {
                        foreach (var element in horizontalSPDetails.Children)
                        {
                            if (element is StackPanel verticalSPDetails)
                            {
                                foreach (var innerElement in verticalSPDetails.Children)
                                {
                                    if (innerElement is TextBlock label)
                                    {
                                        labelText = label.Text;
                                    }
                                    if (innerElement is TextBox textBox)
                                    {
                                        string text = textBox.Text;

                                        if (labelText == "Name")
                                            name = text;
                                        else if (labelText == "Phone")
                                            phone = text;
                                        else if (labelText == "I/C")
                                            ic = text;
                                    }
                                    else if (innerElement is ComboBox comboBox)
                                    {
                                        if (comboBox.SelectedItem != null)
                                        {
                                            gender = (comboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    try
                    {
                        PassengerDetails details = new PassengerDetails(name, gender, phone, ic);
                        passengerDetailsList.Add(details);

                        await firebaseHelper.AddUser(details);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

        }

        private void btnBookingPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BookingPage));

        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpManagement));
        }
    }
}
