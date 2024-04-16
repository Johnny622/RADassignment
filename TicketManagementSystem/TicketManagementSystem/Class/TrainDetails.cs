using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Class
{
    public class TrainDetails
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public int trainID {  get; set; }
        public int price { get; set; }
        public int availableseat { get; set; }
        public string departdate { get; set; }
        public string arrivaldate { get; set; }
        public string departtime { get; set; }
        public string arrivaltime { get; set; }
    }
}
