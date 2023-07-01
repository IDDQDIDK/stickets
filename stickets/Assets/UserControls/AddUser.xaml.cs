using ControlzEx.Standard;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stickets.Assets.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
            Birthdate.DisplayDateEnd = DateTime.Now.AddYears(-18);
            Birthdate.DisplayDateStart = DateTime.Now.AddYears(65);
            System.Data.DataTable table = Classes.Connection.GetTable("SELECT * FROM Roles WHERE Title != 'Менеджер'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.Role.Items.Add(table.Rows[i]["Title"].ToString());
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text.Length != 0 && SecondName.Text.Length != 0 && Patronymic.Text.Length != 0 && Phone.Text.Length != 0 && Email.Text.Length != 0 && Login.Text.Length != 0 && Passcode.Text.Length != 0 && Passport.Text.Length != 0 && Role.SelectedItem != null)
            {
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO Users (Second_Name, First_Name, Patronymic, Phone, Birth, Email, Login, Passcode, Passport, RoleID, IsWorking) VALUES ('" + FirstName.Text + "', '" + SecondName.Text + "', '" + Patronymic.Text + "', '" + Phone.Text + "', '" + Birthdate.DisplayDate.ToString("yyyy-MM-dd") + "', '" + Email.Text + "', '" + Login.Text + "', '" + Passcode.Text + "', '" + Passport.Text + "', '2', 'Работает')", Classes.Connection.con);
                command.ExecuteNonQuery();
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
            Classes.UserData.users.LoadData();
        }

        private void SecondName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.Letters);
        }

        private void FirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.Letters);
        }

        private void Patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.Letters);
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.Numbers);
        }

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.EngLetters);
        }

        private void Passport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(Classes.ChekImput.Numbers);
        }
    }
}
