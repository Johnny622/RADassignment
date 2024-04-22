using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
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
    public sealed partial class DeleteRoute : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public DeleteRoute()
        {
            this.InitializeComponent();
            loadFirebase();
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListStaticData.trainID = btn.Tag.ToString();
            this.Frame.Navigate(typeof(UpdateRoute));
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn.Tag != null)
                {
                    TrainDetails traindetail = await firebaseHelper.GetAllRouteByID(btn.Tag.ToString());
                    if (traindetail != null)
                    {
                        ContentDialog deleteConfirmation = new ContentDialog()
                        {
                            Title = "Delete Confirmation",
                            Content = "Do You Want To Delete This Route\n-> " + traindetail.trainID + " ? \nWARNING!! : ANY DELETE CANNOT BE UNDO.",
                            CloseButtonText = "Cancel",
                            SecondaryButtonText = "Delete"
                        };
                        ContentDialogResult result = await deleteConfirmation.ShowAsync();

                        if (result == ContentDialogResult.Secondary)
                        {
                            await firebaseHelper.DeleteRoute(btn.Tag.ToString());
                            loadFirebase();
                            DisplayDialog("Success", "Train Deleted Successfully");
                        }
                    }
                    else
                    {
                        DisplayDialog("Error", "Train detail not found for the given trainID.");
                    }

                }

            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
                DisplayDialog("Error", "Error Message: " + theException.Message);
                Console.WriteLine("trainDetails or trainDetails.trainID is null");
            }
        }

        private async void loadFirebase()
        {
            try
            {
                List<TrainDetails> td = new List<TrainDetails>();
                td = await firebaseHelper.GetAllRoute();
                TrainInfoList.ItemsSource = td;
                ListStaticData.train = td;
          
            }catch(Exception e)
            {
                DisplayDialog("Error", "Error Message: " + e.Message);
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainManagement));
        }

        private async void DisplayDialog(string title, string content) 
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();


        }
    }
}
