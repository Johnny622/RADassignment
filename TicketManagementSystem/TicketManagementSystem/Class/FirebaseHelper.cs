using Firebase.Database;
using Firebase.Database.Query;
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
                  SeatNumber = item.Object.SeatNumber,
              }).ToList();
        }

        public async Task AddUserDetail(UserDetail user)
        {
            await firebase
           .Child("Users")
           .PostAsync(JsonConvert.SerializeObject(user));
        }

        public async Task<List<UserDetail>> GetUserDetails()
        {
            return (await firebase
              .Child("Users")
              .OnceAsync<UserDetail>()).Select(item => new UserDetail
              {
                  UserId = item.Key.ToString(),
                  UserName = item.Object.UserName,
                  Gender = item.Object.Gender,
                  Email = item.Object.Email,
                  Phone = item.Object.Phone,
                  IC = item.Object.IC,
                  Password = item.Object.Password,
                  ProfileName = item.Object.ProfileName,
                  ProfileURL = item.Object.ProfileURL,
              }).ToList();
        }

        public async Task<UserDetail> GetUserDetailsByUserId(string userId)
        {
            var userDetailsList = await firebase
                .Child("Users")
                .OnceAsync<UserDetail>();

            var userDetail = userDetailsList
                .Select(item => new UserDetail
                {
                    UserId = item.Key,
                    UserName = item.Object.UserName,
                    Gender = item.Object.Gender,
                    Email = item.Object.Email,
                    Phone = item.Object.Phone,
                    IC = item.Object.IC,
                    Password = item.Object.Password,
                    ProfileName = item.Object.ProfileName,
                    ProfileURL = item.Object.ProfileURL,
                })
                .FirstOrDefault(u => u.UserId == userId);

            return userDetail;
        }

        public async Task<UserDetail> GetUserDetailsByEmail(string email)
        {
            var userDetailsList = await firebase
                .Child("Users")
                .OnceAsync<UserDetail>();

            var userDetail = userDetailsList
                .Select(item => new UserDetail
                {
                    UserId = item.Key.ToString(),
                    UserName = item.Object.UserName,
                    Gender = item.Object.Gender,
                    Email = item.Object.Email,
                    Phone = item.Object.Phone,
                    IC = item.Object.IC,
                    Password = item.Object.Password,
                    ProfileName = item.Object.ProfileName,
                    ProfileURL = item.Object.ProfileURL,
                })
                .FirstOrDefault(u => u.Email == email);

            return userDetail;
        }
        public async Task UpdateUser(UserDetail u)
        {
            //Solution 1
            await firebase
            .Child("Users")
            .Child(u.UserId)
            .PutAsync(JsonConvert.SerializeObject(u));
        }
        public async Task DeleteUser(string key)
        {
            await firebase.Child("Users").Child(key).DeleteAsync(); //using firebase primary key
        }

        /* For Admin Usage */

        public async Task AddAdminDetail(AdminDetail admin)
        {
            await firebase
           .Child("Admin")
           .PostAsync(JsonConvert.SerializeObject(admin));
        }
        public async Task<List<AdminDetail>> GetAdminDetails()
        {
            return (await firebase
              .Child("Admin")
              .OnceAsync<AdminDetail>()).Select(item => new AdminDetail
              {
                  AdminId = item.Key.ToString(),
                  AdminName = item.Object.AdminName,
                  Gender = item.Object.Gender,
                  Email = item.Object.Email,
                  Phone = item.Object.Phone,
                  IC = item.Object.IC,
                  Password = item.Object.Password,
              }).ToList();
        }
        public async Task<AdminDetail> GetAdminDetailsByEmail(string email)
        {
            var adminDetailsList = await firebase
                .Child("Admin")
                .OnceAsync<AdminDetail>();

            var adminDetail = adminDetailsList
                .Select(item => new AdminDetail
                {
                    AdminId = item.Key.ToString(),
                    AdminName = item.Object.AdminName,
                    Gender = item.Object.Gender,
                    Email = item.Object.Email,
                    Phone = item.Object.Phone,
                    IC = item.Object.IC,
                    Password = item.Object.Password,
                })
                .FirstOrDefault(u => u.Email == email);

            return adminDetail;
        }
        public async Task UpdateAdmin(AdminDetail a)
        {
            //Solution 1
            await firebase
            .Child("Admin")
            .Child(a.AdminId)
            .PutAsync(JsonConvert.SerializeObject(a));
        }

        public async Task DeleteAdmin(string key)
        {
            await firebase.Child("Admin").Child(key).DeleteAsync(); //using firebase primary key
        }

        /* For Admin Usage */
        public async Task AddRoute(TrainDetails route)
        {
            await firebase
                .Child("Route")
                .PostAsync(JsonConvert.SerializeObject(route));
        }


        public async Task<List<TrainDetails>> GetAllRoute()
        {
            return (await firebase
              .Child("Route")
              .OnceAsync<TrainDetails>()).Select(item => new TrainDetails

              {
                  TrainKey = item.Key,
                  trainID = item.Object.trainID,
                  origin = item.Object.origin,
                  destination = item.Object.destination,
                  price = item.Object.price,
                  availableseat = item.Object.availableseat,
                  departdate = item.Object.departdate,
                  arrivaldate = item.Object.arrivaldate,
                  departtime = item.Object.departtime,
                  arrivaltime = item.Object.arrivaltime,
              }).ToList();
        }

        public async Task<TrainDetails> GetAllRouteByID(String trainkey)
        {
            var trainDetailsList = await firebase
                .Child("Route")
                .OnceAsync<TrainDetails>();

            var traindetail = trainDetailsList
                .Select(item => new TrainDetails

                {
                    TrainKey = item.Key,
                    trainID = item.Object.trainID,
                    origin = item.Object.origin,    
                    destination = item.Object.destination,
                    price = item.Object.price,
                    availableseat = item.Object.availableseat,
                    departdate = item.Object.departdate,
                    arrivaldate=item.Object.arrivaldate,


                }).FirstOrDefault(t => t.TrainKey == trainkey);   
            return traindetail;
        }

        public async Task DeleteRoute(string key)
        {
            await firebase.Child("Route").Child(key).DeleteAsync(); //using firebase primary key
        }

        public async Task UpdateRoute(TrainDetails t)
        {
            //Solution 1
            await firebase
            .Child("Route")
            .Child(t.TrainKey)
            .PutAsync(JsonConvert.SerializeObject(t));
        }

      

    }
}
