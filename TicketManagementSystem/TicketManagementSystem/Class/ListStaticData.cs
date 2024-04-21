using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TicketManagementSystem.Class
{
    public class ListStaticData
    {
        public static List<UserDetail> users = new List<UserDetail>(); //get all the data in USER
        public static string userId { get; set; }
        public static List<PassengerDetails> bookedList = new List<PassengerDetails>();

        public static string bookingId { get; set; }

        public static List<Button> SelectedSeatButtons { get; set; } = new List<Button>();
        public static int noOfPax {  get; set; }
    
    }
   
}
