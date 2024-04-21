using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    /////if selected seat is less than the number of pax, cannot proceed to reserve

    public sealed partial class SeatSelectionPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        private List<PassengerDetails> bookedList = new List<PassengerDetails>();

        private List<Button> selectedSeatButtons = new List<Button>(); // Track selected seat buttons

        private int numberOfPax = 3;

        public SeatSelectionPage()
        {
            this.InitializeComponent();
            GenerateSeats(40);
            LoadLatestSeat();
            
        }

        private void GenerateSeats(int totalSeats)
        {
            const int seatsPerRow = 10;
            int columns = (totalSeats + seatsPerRow - 1) / seatsPerRow;
            int remainingSeats = totalSeats % seatsPerRow;
            if (remainingSeats == 0)
            {
                remainingSeats = seatsPerRow;
            }

            char[] seatLetters = { 'A', 'B', 'C', 'D' };

            for (int column = 0; column < columns; column++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

                int seatsInCurrentColumn = column == columns - 1 ? remainingSeats : seatsPerRow;

                for (int row = 0; row < seatsInCurrentColumn; row++)
                {
                    mainGrid.RowDefinitions.Add(new RowDefinition());

                    TextBlock seatNumberTextBlock = new TextBlock
                    {
                        Text = $"{row + 1}{seatLetters[column]}",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(0, 0, 0, 5)
                    };

                    Image seatImage = new Image
                    {
                        Source = new BitmapImage(new Uri("ms-appx:///Assets/chair.png")),
                        Width = 30,
                        Height = 30
                    };

                    Button seatButton = new Button
                    {
                        Content = new StackPanel { Children = { seatImage, seatNumberTextBlock } },
                        Background = new SolidColorBrush(Colors.Transparent),
                        Tag = $"{row + 1}{seatLetters[column]}"
                    };

                    seatButton.Click += SeatButton_Click;

                    Grid.SetColumn(seatButton, column);
                    Grid.SetRow(seatButton, row);

                    mainGrid.Children.Add(seatButton);
                }
            }
        }

        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string seatNumber = clickedButton.Tag.ToString();

            ListStaticData.noOfPax = numberOfPax;

            try
            {
                if (selectedSeatButtons.Count < numberOfPax)
                {
                    if (selectedSeatButtons.Contains(clickedButton))
                    {
                        DeselectSeat(clickedButton);
                        ListStaticData.SelectedSeatButtons.Remove(clickedButton);
                    }
                    else if (!IsSeatBooked(seatNumber)) 
                    {
                        SelectSeat(clickedButton);
                        ListStaticData.SelectedSeatButtons.Add(clickedButton);
                    }
                    
                }
                else
                {
                    if (selectedSeatButtons.Contains(clickedButton))
                    {
                        DeselectSeat(clickedButton);
                        ListStaticData.SelectedSeatButtons.Remove(clickedButton);
                    }
                    else
                    {
                        DisplayDialog("You have already selected " + numberOfPax + "seats.");
                    }
                }

                DisplaySelectedSeats();
            }
            catch (Exception theException)
            {
                DisplayDialog("An error occurred: " + theException.Message);
            }
        }

        private bool IsSeatBooked(string seatNumber)
        {
            return bookedList.Any(passenger => passenger.SeatNumber == seatNumber);
        }

        private void DisplaySelectedSeats()
        {
            StringBuilder selectedSeatsText = new StringBuilder();
            bool isMaxSeatsSelected = selectedSeatButtons.Count >= numberOfPax;

            if (selectedSeatButtons.Count > 0)
            {
                selectedSeatsText.Append("Selected Seats: ");

                foreach (Button selectedSeat in selectedSeatButtons)
                {
                    selectedSeatsText.Append($"{selectedSeat.Tag.ToString()}, ");
                }

                // Remove the trailing comma and space
                selectedSeatsText.Length -= 2;
            }

            SelectedSeatsTextBlock.Text = selectedSeatsText.ToString();

            if (selectedSeatButtons.Count == numberOfPax)
            {
                SelectedSeatsTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                SelectedSeatsTextBlock.Visibility = Visibility.Collapsed;
            }           
        }

        private void SelectSeat(Button seatButton)
        {
            string seatNumber = seatButton.Tag.ToString();
            selectedSeatButtons.Add(seatButton);
            UpdateSeatAppearance(seatNumber, isBooked: true);
        }

        private void DeselectSeat(Button seatButton)
        {
            string seatNumber = seatButton.Tag.ToString();
            selectedSeatButtons.Remove(seatButton);
            UpdateSeatAppearance(seatNumber, isBooked: false);
        }

        public void UpdateSeatAppearance(string seatNumber, bool isBooked)
        {
            // Find the corresponding button with the given seat number
            Button seatButton = FindSeatButton(seatNumber);

            if (seatButton != null)
            {
                // Update the appearance of the seat button
                if (seatButton.Content is StackPanel stackPanel)
                {
                    if (stackPanel.Children[0] is Image seatImage)
                    {
                        if (isBooked)
                        {
                            seatImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/booked_chair.png"));
                        }
                        else
                        {
                            seatImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/chair.png"));
                        }
                    }
                }
            }
        }

        private Button FindSeatButton(string seatNumber)
        {
            foreach (var child in mainGrid.Children)
                if (child is Button seatButton && seatButton.Tag.ToString() == seatNumber)
                    return seatButton;

            return null;
        }

        private async void LoadLatestSeat()
        {
            try
            {
                bookedList = await firebaseHelper.GetAllUsers();

                if (bookedList.Count > 0)
                {
                    foreach (PassengerDetails passenger in bookedList)
                    {
                        // Update seat appearance for each booked seat
                        UpdateSeatAppearance(passenger.SeatNumber, isBooked: true);
                    }
                }

                // UpdateAvailableSeats();
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private void DisplayDialog(string content)
        {
            DisplayErrorTextBlock.Text = content;
            DisplayErrorTextBlock.Visibility = Visibility.Visible;
        }

    }
}
