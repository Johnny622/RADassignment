using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
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

    public sealed partial class SeatSelectionPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        private HashSet<string> bookedSeats = new HashSet<string>(); // Track booked seats
        private List<Button> selectedSeatButtons = new List<Button>(); // Track selected seat buttons
        private int numberOfPax = 3; 

        public SeatSelectionPage()
        {
            this.InitializeComponent();
            GenerateSeats(38);
        }

        private void GenerateSeats(int totalSeats)
        {
            const int seatsPerRow = 10;
            int columns = (totalSeats + seatsPerRow - 1) / seatsPerRow;
            int remainingSeats = totalSeats % seatsPerRow;

            char[] seatLetters = { 'A', 'B', 'C', 'D' };

            for (int column = 0; column < columns; column++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

                int seatsInCurrentColumn = column == columns - 1 ? remainingSeats : seatsPerRow;

                for (int row = 0; row < seatsInCurrentColumn; row++)
                {
                    if (column == 0)
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

            if (!IsSeatAvailable(seatNumber)) //seat not available
            {
                return;       
            }

            else //seat available
            {
                if (SeatManagement.SelectedSeatButtons == null)
                {
                    SeatManagement.SelectedSeatButtons = new List<Button>();
                }
                else
                {
                    if (SeatManagement.SelectedSeatButtons.Contains(clickedButton))
                    {
                        DeselectSeat(clickedButton);
                        SeatManagement.SelectedSeatButtons.Remove(clickedButton);
                    }
                    else //delect old seat + select new seat happened in one click
                    {
                        if (selectedSeatButtons.Count >= numberOfPax)
                        {
                            DeselectSeat(selectedSeatButtons.First());
                            SeatManagement.SelectedSeatButtons.Remove(selectedSeatButtons.First());
                        }
                        SelectSeat(clickedButton);
                        SeatManagement.SelectedSeatButtons.Add(clickedButton);
                    }
                }
            }
        }

        private void SelectSeat(Button seatButton)
        {
            selectedSeatButtons.Add(seatButton);

            UpdateSeatAppearance(seatButton, isBooked: true);
        }

        private void DeselectSeat(Button seatButton)
        {
            selectedSeatButtons.Remove(seatButton);

            UpdateSeatAppearance(seatButton, isBooked: false);
        }

        public bool IsSeatAvailable(string seatNumber)
        {
            return !bookedSeats.Contains(seatNumber); 
        }

        public void ReserveSeat(string seatNumber)
        {
            bookedSeats.Add(seatNumber);
        }
        public void ReleaseSeat(string seatNumber)
        {
            bookedSeats.Remove(seatNumber);
        }

        public void UpdateSeatAppearance(Button seatButton, bool isBooked)
        {
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
}
