using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        string ID;
        public User(string ID, string SecondName, string FirstName, string Patronymic, string Phone, string BirthDate, string Email, string Login, string Passcode, string Passport, string Role, string Status)
        {
            InitializeComponent();
            this.ID = ID;
            this.FirstName.Text = FirstName;
            this.SecondName.Text = SecondName;
            this.Patronymic.Text = Patronymic;
            this.Phone.Text = Phone;
            this.Birthdate.Text = BirthDate;
            this.Email.Text = Email;
            this.Login.Text = Login;
            this.Passcode.Text = Passcode;
            this.Passport.Text = Passport;
            this.Status.Text = Status;
            this.Role.SelectedIndex = Convert.ToInt32(Role) - 1;

            System.Data.DataTable table = Classes.Connection.GetTable("SELECT * FROM roles WHERE Title != 'Менеджер'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.Role.Items.Add(table.Rows[i]["Title"].ToString());
            }
        }

        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (FirstName.Text.Length != 0 && SecondName.Text.Length != 0 && Patronymic.Text.Length != 0 && Phone.Text.Length != 0 && Email.Text.Length != 0 && Login.Text.Length != 0 && Passcode.Text.Length != 0 && Passport.Text.Length != 0 && Role.SelectedItem != null)
        //    {
        //        MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Users SET Second_Name = '" + SecondName.Text + "', First_Name = '" + FirstName.Text + "', Patronymic = '" + Patronymic.Text + "', Phone = '" + Phone.Text + "', Birth = '" + Birthdate.DisplayDate.ToString("yyyy-MM-dd") + "', Email = '" + Email.Text + "', Login = '" + Login.Text + "', Passcode = '" + Passcode.Text + "', Passport = '" + Passport.Text + "', RoleID = '" + (Role.SelectedIndex + 1) + "' WHERE Users.ID = " + ID, Classes.Connection.con);
        //        command.ExecuteNonQuery();
        //    }
        //    else
        //        MessageBox.Show("Вы должны заполнить все поля!");
        //    Classes.UserData.users.LoadData();
        //}

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlCommand command;
            if (Status.Text == "Работает")
            {
                command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Users SET IsWorking = 'Уволен' WHERE ID = " + ID, Classes.Connection.con);
            }
            else
                command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Users SET IsWorking = 'Работает' WHERE ID = " + ID, Classes.Connection.con);
            command.ExecuteNonQuery();
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
