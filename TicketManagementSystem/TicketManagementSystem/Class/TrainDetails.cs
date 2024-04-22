using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Class
{
    public class TrainDetails
    {
        public string TrainKey {  get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string trainID {  get; set; }
        public string price { get; set; }
        public string availableseat { get; set; }
        public string departdate { get; set; }
        public string arrivaldate { get; set; }
        public string departtime { get; set; }
        public string arrivaltime { get; set; }
    }
}
