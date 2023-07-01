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

namespace stickets.Windows.Manager
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Users.Work win = new Users.Work();
            win.Show();
        }

        private void Timetable_Click(object sender, RoutedEventArgs e)
        {
            Timetable.Work win = new Timetable.Work();
            win.Show();
        }

        private void Perfomances_Click(object sender, RoutedEventArgs e)
        {
            Performances.View win = new Performances.View();
            win.Show();
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            Sales.View win = new Sales.View();
            win.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Assets.Classes.UserData.auth.Show();
        }
    }
}
