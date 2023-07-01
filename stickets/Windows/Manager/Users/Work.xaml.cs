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

namespace stickets.Windows.Manager.Users
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work : Window
    {
        public Work()
        {
            InitializeComponent();
            Assets.Classes.UserData.users = this;
            LoadData();
        }
        string Search = " WHERE First_Name LIKE '%%' AND  RoleID != 1 ", Filtration, AscDesc;

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = " WHERE (First_Name LIKE '%" + SearchBox.Text + "%' OR Second_Name LIKE '%" + SearchBox.Text + "%' OR Patronymic LIKE '%" + SearchBox.Text + "%') AND RoleID = 1  ";
            LoadData();
        }

        private void FiltrationBox_DropDownClosed(object sender, EventArgs e)
        {
            if (FiltrationBox.SelectedIndex == 0)
                Filtration = "";
            else
                Filtration = " AND RoleID = " + FiltrationBox.SelectedIndex;
            LoadData();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY First_Name ASC ";
            LoadData();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY First_Name DESC ";
            LoadData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public void LoadData()
        {
            UsersBox.Children.Clear();
            UsersBox.Children.Add(new Assets.UserControls.AddUser());
            DataTable Users = Assets.Classes.Connection.GetTable("SELECT * FROM Users " + Search + Filtration + AscDesc);
            for (int i = 0; i < Users.Rows.Count; i++)
                UsersBox.Children.Add(new Assets.UserControls.User(Users.Rows[i][0].ToString(), Users.Rows[i][1].ToString(), Users.Rows[i][2].ToString(), Users.Rows[i][3].ToString(), Users.Rows[i][4].ToString(), Users.Rows[i][5].ToString(), Users.Rows[i][6].ToString(), Users.Rows[i][7].ToString(), Users.Rows[i][8].ToString(), Users.Rows[i][9].ToString(), Users.Rows[i][10].ToString(), Users.Rows[i][11].ToString()));
        }
    }
}
