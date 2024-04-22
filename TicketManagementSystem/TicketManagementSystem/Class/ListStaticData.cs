using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Class
{
    public class ListStaticData
    {
        public static List<UserDetail> users = new List<UserDetail>(); //get all the data in USER
        public static string userId { get; set; }


        public static List<TrainDetails> train = new List<TrainDetails>();
        public static string trainID {  get; set; }
    
    }

   

}
