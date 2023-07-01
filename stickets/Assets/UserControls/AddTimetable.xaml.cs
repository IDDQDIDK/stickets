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
    /// Логика взаимодействия для AddTimetable.xaml
    /// </summary>
    public partial class AddTimetable : UserControl
    {
        public AddTimetable()
        {
            InitializeComponent();

            Date.DisplayDateStart = DateTime.Now;
            System.Data.DataTable table = Classes.Connection.GetTable("SELECT * FROM performances");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Perfomance.Items.Add(table.Rows[i]["Title"]);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Date.DisplayDate != null && Time.Text != null && Perfomance.Text.Length != 0)
            {
                if (Convert.ToInt32(Time.Text.Split(':')[0]) > 8 && Convert.ToInt32(Time.Text.Split(':')[0]) < 21)
                {
                    DataTable table = Classes.Connection.GetTable("SELECT * FROM timetable WHERE addtime(WhenStarts, '2:00:00') = '" + Date.DisplayDate.ToString("yyyy-MM-dd") + " " + Time.Text + "'");
                    if (table.Rows.Count != 0)
                    {
                        System.Data.DataTable perfs = Assets.Classes.Connection.GetTable("SELECT * FROM performances WHERE Title = '" + Perfomance.Text + "'");
                        MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO timetable (WhenStarts, PerfomanceID, IsDone) VALUES ('" + Convert.ToDateTime(Date.Text).ToString("yyyy-MM-dd") + " " + Time.Text + "', " + perfs.Rows[0]["ID"] + ", 'Не поставлена')", Classes.Connection.con);
                        com.ExecuteNonQuery();
                        Classes.UserData.timetable.LoadData();
                    }
                    else
                        MessageBox.Show("Вы не можете начать спектакль раньше 2 часов после другого!");
                }
                else
                {
                    MessageBox.Show("Вы выбрани нерабочее время!");
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }
    }
}
