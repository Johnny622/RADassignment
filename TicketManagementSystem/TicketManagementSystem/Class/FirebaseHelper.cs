using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace TicketManagementSystem.Class
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://trainmanagementsystem-6fec6-default-rtdb.firebaseio.com/");

        public async Task AddUser(PassengerDetails passenger)
        {
            await firebase
           .Child("Passengers")
           .PostAsync(JsonConvert.SerializeObject(passenger));
        }

        public async Task<List<PassengerDetails>> GetAllUsers()
        {

            return (await firebase
              .Child("Passengers")
              .OnceAsync<PassengerDetails>()).Select(item => new PassengerDetails
              {
                  Name = item.Object.Name,
                  Phone = item.Object.Phone,
              }).ToList();
        }
    }
}
