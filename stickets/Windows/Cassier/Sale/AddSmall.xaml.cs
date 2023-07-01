using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using stickets.Assets.UserControls.Cassier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace stickets.Windows.Cassier.Sale
{
    /// <summary>
    /// Логика взаимодействия для AddSmall.xaml
    /// </summary>
    public partial class AddSmall : Window
    {
        string When, TimetableID;
        int TotalCost = 0;
        string Hall, ID;
        public AddSmall(string CostPerfomance, string TimetableID, string TitlePerformance, string WhenStarts)
        {
            InitializeComponent();
            When = WhenStarts;
            this.TimetableID = TimetableID;
            Assets.Classes.UserData.AddSmall = this;
            this.Cost.Text += CostPerfomance + " + ";
            this.PerformanceTitle.Text += TitlePerformance;

            TotalCost += Convert.ToInt32(CostPerfomance);


            LoadData();



            System.Data.DataTable table = Assets.Classes.Connection.GetTable("SELECT * FROM Halls WHERE ID > 13 ");
            TextBlock[] prices = new TextBlock[4] { Price1, Price2, Price3, Price4 };
            for (int i = 0; i < table.Rows.Count; i++)
            {
                prices[i].Text += table.Rows[i]["Cost"].ToString();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Assets.Classes.UserData.cassier.Show();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (ID != null)
            {
                MySqlCommand com = new MySqlCommand("UPDATE places SET Taken = 'Занято' WHERE ID = " + ID, Assets.Classes.Connection.con);

                com.ExecuteNonQuery();
                LoadData();
                Ticket ticket = new Ticket(PerformanceTitle.Text, Hall, Place.Text, When, TotalCost.ToString(), "Малый зал");
                ticket.Show();
                MySqlCommand sale = new MySqlCommand("INSERT INTO sales (WhenSaled, SellerID, TimetableID, PlaceID) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd t") + "', '" + Assets.Classes.UserData.ID + "', '" + TimetableID + "', '" + ID + "')", Assets.Classes.Connection.con);
                sale.ExecuteNonQuery();
            }
            else
                MessageBox.Show("Вы должны выбрать место!");
        }
        public void UpdatePlace(string Cost, string Place, string Hall, string ID)
        {
            this.PlaceCost.Text = Cost;
            TotalCost += Convert.ToInt32(Cost);
            this.Place.Text = Place;
            this.Hall = Hall;
            this.ID = ID;
        }
        public void LoadData()
        {
            Places.Children.Clear();
            System.Data.DataTable table = Assets.Classes.Connection.GetTable("SELECT * FROM Places JOIN Halls ON HallID = Halls.ID WHERE HallID > 13 ");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Places.Children.Add(new PlaceSmall(table.Rows[i]["ID"].ToString(), table.Rows[i]["Cost"].ToString(), table.Rows[i]["Title"].ToString(), table.Rows[i]["Title1"].ToString(), TimetableID));
            }
        }
    }
}
