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
using System.Windows.Shapes;
using stickets.Assets.Classes;

namespace stickets.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            Connection.con.Open();
            UserData.auth = this;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                DataTable user = Connection.GetTable("SELECT * FROM Users JOIN Roles ON RoleID = roles.ID WHERE Login = '" + Login.Text + "' AND Passcode = '" + Password.Text + "'");
                if (user.Rows.Count != 0)
                {
                    if (user.Rows[0]["IsWorking"].ToString() != "Уволен")
                    {

                        UserData.ID = user.Rows[0][0].ToString();
                        if (user.Rows[0][10].ToString() == "1")
                        {
                            Manager.Menu menu = new Manager.Menu();
                            UserData.Name = user.Rows[0][1].ToString() + " " + user.Rows[0][2].ToString() + " " + user.Rows[0][3].ToString();
                            UserData.Role = user.Rows[0]["Title"].ToString();
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            Cassier.Timetable.View menu = new Cassier.Timetable.View();
                            menu.Show();
                            this.Hide();
                        }
                    }
                    else
                        MessageBox.Show("Вы уволены!");
                }
                else
                     MessageBox.Show("Вы ввели неверный логин или пароль!");

            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }
    }
}
