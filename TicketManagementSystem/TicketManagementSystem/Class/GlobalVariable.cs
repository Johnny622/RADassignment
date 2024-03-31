using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Casting;

namespace TicketManagementSystem
{
    public class GlobalVariable
    {
        public static string CurrentUserID { get; set; }

        public static string CurrentUserEmail { get; set; }

        public static string CurrentAdminID { get; set; }

        public static string CurrentAdminEmail { get; set; }

        public static string CurrentPosition {  get; set; }
    }
}
