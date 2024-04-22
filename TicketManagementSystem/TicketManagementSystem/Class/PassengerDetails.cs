using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Class
{
    public class PassengerDetails
    {
        //Seat reservation details
        public string BookingId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public string Coach { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string IC { get; set; }


        public PassengerDetails()
        {

        }
        public PassengerDetails(string name, string gender, string phone, string ic)
        {
            Name = name;
            Gender = gender;
            Phone = phone;
            IC = ic;
        }
    }

}
