using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : System.Windows.Window
    {
        string When, TimetableID;
        public Add(string CostPerfomance, string TimetableID, string TitlePerformance, string WhenStarts)
        {
            InitializeComponent();
            When = WhenStarts;
            this.TimetableID = TimetableID;
            Assets.Classes.UserData.Add = this;
            this.Cost.Text += CostPerfomance + " + ";
            this.PerformanceTitle.Text += TitlePerformance;

            TotalCost += Convert.ToInt32(CostPerfomance);


            LoadData();



            System.Data.DataTable table = Assets.Classes.Connection.GetTable("SELECT * FROM Halls WHERE Title != 'Амфитеатр' AND ID < 14");
            TextBlock[] prices = new TextBlock[12] { Price1, Price2, Price3, Price4, Price5, Price6, Price7, Price8, Price9, Price10, Price11, Price12 };
            for (int i = 0; i < table.Rows.Count; i++)
            {
                prices[i].Text += table.Rows[i]["Cost"].ToString();
            }
        }
        string Hall, ID;
        int TotalCost = 0;
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
            WrapPanel[] wps = new WrapPanel[12] { Parter, Benuar_Right, Benuar_Left, Beltazh_Centre, Beltazh_Right, Beltazh_Left, Balcony_Centre, Balcony_Right, Balcony_Left, Gallery_Centre, Gallery_Left, Gallery_Right };
            System.Data.DataTable halls = Assets.Classes.Connection.GetTable("SELECT * FROM Halls WHERE Title != 'Амфитеатр' AND ID < 14");
            foreach (var wp in wps)
            {
                wp.Children.Clear();
            }
            for (int i = 0; i < halls.Rows.Count; i++)
            {
                System.Data.DataTable hall = Assets.Classes.Connection.GetTable("SELECT Places.ID AS PlaceID, Halls.Cost, Places.Title as Place, Halls.Title as Hall FROM Places JOIN Halls ON Halls.ID = HallID WHERE Halls.ID = " + halls.Rows[i]["ID"]);
                for (int j = 0; j < hall.Rows.Count; j++)
                {
                    wps[i].Children.Add(new Assets.UserControls.Cassier.Place(hall.Rows[j]["PlaceID"].ToString(), hall.Rows[j]["Cost"].ToString(), hall.Rows[j]["Place"].ToString(), hall.Rows[j]["Hall"].ToString(), TimetableID));

                    if ((hall.Rows[j]["Hall"].ToString() == "Правая ложа галереи" || hall.Rows[j]["Hall"].ToString() == "Правая ложа балкона") && hall.Rows[j]["Place"].ToString().Split(' ')[2] == "6")
                    {
                        System.Windows.Controls.Label label = new System.Windows.Controls.Label();
                        label.Width = 60;
                        wps[i].Children.Add(label);
                    }
                }
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
                Ticket ticket = new Ticket(PerformanceTitle.Text, Hall, Place.Text, When, TotalCost.ToString(), "Большой зал");
                ticket.Show();
                MySqlCommand sale = new MySqlCommand("INSERT INTO sales (WhenSaled, SellerID, TimetableID, PlaceID) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd t") + "', '" + Assets.Classes.UserData.ID + "', '" + TimetableID + "', '" + ID + "')", Assets.Classes.Connection.con);
                sale.ExecuteNonQuery();
            }
            else
                MessageBox.Show("Вы должны выбрать место!");
        }
    }
}
