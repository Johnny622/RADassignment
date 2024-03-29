﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Devices.Bluetooth.Advertisement;

namespace TicketManagementSystem.Class
{
    public class UserDetail
    {
        public string UserId {  get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string IC {  get; set; }
        public string Password { get; set; }

        public UserDetail()
        {

        }
        public UserDetail(string name, string gender, string email, string phone, string ic, string password)
        {
            UserName = name;
            Gender = gender;
            Email = email;
            Phone = phone;
            IC = ic;
            Password = password;
        }
    }
}