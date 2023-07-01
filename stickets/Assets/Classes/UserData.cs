using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stickets.Assets.Classes
{
    internal class UserData
    {
        public static string ID;
        public static string Name;
        public static string Role;
        public static Windows.Authorization auth;
        public static Windows.Manager.Users.Work users;
        public static Windows.Manager.Performances.View perfomances;
        public static Windows.Manager.Timetable.Work timetable;
        public static Windows.Cassier.Timetable.View cassier;
        public static Windows.Cassier.Sale.Add Add;
        public static Windows.Cassier.Sale.AddSmall AddSmall;
    }
}
