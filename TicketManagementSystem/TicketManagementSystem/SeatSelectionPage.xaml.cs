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

    public sealed partial class SeatSelectionPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        private List<PassengerDetails> bookedList = new List<PassengerDetails>();

        private List<Button> selectedSeatButtons = new List<Button>(); // Track selected seat buttons

        private string coach;

        private int numberOfPax = ListStaticData.noOfPax;

        public SeatSelectionPage()
        {
            this.InitializeComponent();
            LoadLayoutForCoach(38, "A");
            coachComboList.SelectionChanged += coachComboList_SelectionChanged;
        }

        private void LoadLayoutForCoach(int totalSeats, string selectedCoach)
        {
            // Clear existing grids
            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            Grid coachGrid = new Grid();
            mainGrid.Children.Add(coachGrid);

            GenerateSeats(coachGrid, totalSeats, selectedCoach);

            // Reload latest seat appearance for the selected coach
            LoadLatestSeat();
            LoadSelectedSeat();
        }

        private void GenerateSeats(Grid coachGrid, int totalSeats, string coach)
        {
            const int seatsPerRow = 10;
            int columns = (totalSeats + seatsPerRow - 1) / seatsPerRow;
            int remainingSeats = totalSeats % seatsPerRow;

            char[] seatLetters = { 'A', 'B', 'C', 'D' };

            for (int column = 0; column < columns; column++)
            {
                coachGrid.ColumnDefinitions.Add(new ColumnDefinition());

                int seatsInCurrentColumn = column == columns - 1 ? remainingSeats : seatsPerRow;

                for (int row = 0; row < seatsInCurrentColumn; row++)
                {
                    if (column == 0)
                        coachGrid.RowDefinitions.Add(new RowDefinition());

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
                        Tag = $"{row + 1}{seatLetters[column]}",
                        Name = coach
                    };


                    seatButton.Click += SeatButton_Click;

                    Grid.SetColumn(seatButton, column);
                    Grid.SetRow(seatButton, row);
                    coachGrid.Children.Add(seatButton); // Add the button to coachGrid instead of mainGrid
                }
            }
        }

        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string seatNumber = clickedButton.Tag.ToString();

            try
            {
                if (selectedSeatButtons.Count < numberOfPax)
                {
                    if (selectedSeatButtons.Contains(clickedButton))
                    {
                        DeselectSeat(clickedButton);
                        ListStaticData.SelectedSeatButtons.Remove(clickedButton);
                    }
                    else if (!IsSeatBooked(seatNumber, clickedButton.Name)) //coach = clickedButton.Name
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

                        if (selectedSeatButtons.Count > numberOfPax)
                        {
                            DisplayDialog("You have already selected " + numberOfPax + " seats.");
                        }
                        else
                        {
                            DisplayDialog(null);
                        }
                    }
                    else
                    {
                        DisplayDialog("You have already selected " + numberOfPax + " seats.");
                    }
                }

                DisplaySelectedSeats();
            }
            catch (Exception theException)
            {
                DisplayDialog("An error occurred: " + theException.Message);
            }
        }

        private void coachComboList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex != -1)
            {
                coach = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
                //ListStaticData.coach = coach;

                LoadLayoutForCoach(38, coach);
            }
            else
            {
                DisplayDialog("No coach selected.");
            }
        }

        private bool IsSeatBooked(string seatNumber, string coach)
        {
            return bookedList.Any(passenger => passenger.SeatNumber == seatNumber && passenger.Coach == coach);
        }

        private void DisplaySelectedSeats()
        {
            StringBuilder selectedSeatsText = new StringBuilder();

            if (selectedSeatButtons.Count > 0)
            {
                selectedSeatsText.Append("Selected Seats: ");

                foreach (Button selectedSeat in selectedSeatButtons)
                {
                    selectedSeatsText.Append($"{"(" + selectedSeat.Name + ")"}{selectedSeat.Tag.ToString()}, ");
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
            string coach = seatButton.Name;

            ListStaticData.coach = coach;
            selectedSeatButtons.Add(seatButton);
            UpdateSeatAppearance(seatNumber, coach, isBooked: true);
        }

        private void DeselectSeat(Button seatButton)
        {
            string seatNumber = seatButton.Tag.ToString();
            string coach = seatButton.Name;

            selectedSeatButtons.Remove(seatButton);
            UpdateSeatAppearance(seatNumber, coach, isBooked: false);
        }

        public void UpdateSeatAppearance(string seatNumber, string coach, bool isBooked)
        {
            Button seatButton = FindSeatButton(seatNumber, coach);

            if (seatButton != null)
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

        private Button FindSeatButton(string seatNumber, string coach)
        {
            foreach (var child in mainGrid.Children)
            {
                if (child is Grid coachGrid)
                {
                    foreach (var gridChild in coachGrid.Children)
                    {
                        if (gridChild is Button seatButton &&
                            seatButton.Tag.ToString() == seatNumber &&
                            seatButton.Name == coach)
                        {
                            return seatButton;
                        }
                    }
                }
            }

            return null;
        }

        private async void LoadLatestSeat()
        {
            try
            {
                //Load reserved seat from firebase
                bookedList = await firebaseHelper.GetAllUsers();

                if (bookedList.Count > 0)
                {
                    foreach (PassengerDetails passenger in bookedList)
                    {
                        UpdateSeatAppearance(passenger.SeatNumber, passenger.Coach, isBooked: true);
                    }
                }
            }

            catch (Exception theException)
            {
                DisplayDialog("An error occurred: " + theException.Message);
            }
        }

        private void LoadSelectedSeat()
        {
            try
            {
                foreach (Button selectedButton in selectedSeatButtons)
                {
                    UpdateSeatAppearance(selectedButton.Tag.ToString(), selectedButton.Name, isBooked: true);
                }
            }
            catch (Exception theException)
            {
                DisplayDialog("An error occurred: " + theException.Message);
            }
        }

        private void DisplayDialog(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                DisplayErrorTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                DisplayErrorTextBlock.Text = content;
                DisplayErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}


