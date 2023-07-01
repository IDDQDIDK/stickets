using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace stickets.Assets.Classes
{
    internal class Connection
    {
        public static MySqlConnection con = new MySqlConnection("Server=localhost;Database=stickets;Uid=root;Pwd=IDDQD;");
        public static DataTable GetTable(string select)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(select, con);
            adapter.Fill(table);

            return table;
        }
    }
}
