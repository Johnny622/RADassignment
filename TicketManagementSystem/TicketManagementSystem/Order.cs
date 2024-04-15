using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem
{
    public class Order
    {
        public string SenderId { get; set; }

        public int CardNo { get; set; }

        public string ReceiverID { get; set; }

        public int NumTickets { get; set; }

        public double UnitPrice { get; set; }
    }
}
