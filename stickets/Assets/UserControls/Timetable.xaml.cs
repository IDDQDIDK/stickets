using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stickets.Assets.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class Timetable : UserControl
    {
        string ID;
        public Timetable(string ID, string WhenStarts, string PerfomanceID, string IsDone)
        {
            InitializeComponent();
            Date.DisplayDate = Convert.ToDateTime(WhenStarts);
            Time.Text = Convert.ToString(WhenStarts).Split(' ')[1];
            DataTable data = Classes.Connection.GetTable("SELECT * FROM performances");
            this.ID = ID;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                TextBlock block = new TextBlock();
                block.Text = data.Rows[i]["Title"].ToString();
                item.Tag = data.Rows[i]["ID"].ToString();
                item.Content = block;
                Perfomance.Items.Add(item);
            }
            data = Classes.Connection.GetTable("SELECT * FROM performances WHERE ID = " + PerfomanceID);
            Perfomance.Text = data.Rows[0]["Title"].ToString();
            Status.Text = IsDone;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Date.DisplayDate.ToString().Length != 0 && Time.Text.Length != 0 && Perfomance.Text.Length != 0)
            {
                if (Convert.ToInt32(Time.Text.Split(':')[0]) > 8 && Convert.ToInt32(Time.Text.Split(':')[0]) < 21)
                {
                    System.Data.DataTable perfs = Assets.Classes.Connection.GetTable("SELECT * FROM performances WHERE Title = '" + Perfomance.Text + "'");
                    MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand("UPDATE timetable SET WhenStarts = '" + Date.DisplayDate.ToString("yyyy-MM-dd") + " " + Time.Text + "', PerfomanceID = " + perfs.Rows[0]["ID"] + " WHERE timetable.ID = " + ID, Classes.Connection.con);
                    com.ExecuteNonQuery();
                    Classes.UserData.timetable.LoadData();


                }
                else
                {
                    MessageBox.Show("Вы выбрани нерабочее время!");
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Status_MouseEnter(object sender, MouseEventArgs e)
        {
            Status.Visibility = Visibility.Hidden;
        }

        private void Status_MouseLeave(object sender, MouseEventArgs e)
        {
            Status.Visibility = Visibility.Visible;
        }
    }
}
