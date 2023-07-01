using Microsoft.Office.Interop.Excel;
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

namespace stickets.Windows.Cassier.Timetable
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : System.Windows.Window
    {
        string Search = " WHERE performances.Title LIKE '%%' ", Filtration, Sort;
        public View()
        {
            InitializeComponent();

            FiltrationBox.Items.Add("Все жанры");
            System.Data.DataTable data = Assets.Classes.Connection.GetTable("SELECT * FROM Genres");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                FiltrationBox.Items.Add(data.Rows[i][1].ToString());
            }
            LoadData();
            Assets.Classes.UserData.cassier = this;
        }
        public void LoadData()
        {
            TimetableBox.Children.Clear();
            System.Data.DataTable data = Assets.Classes.Connection.GetTable("SELECT timetable.ID, WhenStarts, performances.Title, Cost, agerestrictions.Title, Photo FROM timetable JOIN performances ON PerfomanceID = performances.ID JOIN agerestrictions ON AgeRestrictionID = agerestrictions.ID JOIN Genres ON GenreID = Genres.ID " + Search + Filtration + Sort);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                TimetableBox.Children.Add(new Assets.UserControls.Cassier.Timetable(data.Rows[i][0].ToString(), Convert.ToDateTime(data.Rows[i][1]), data.Rows[i][2].ToString(), data.Rows[i][3].ToString(), data.Rows[i][4].ToString(), (byte[])data.Rows[i][5]));
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = " WHERE performances.Title LIKE '%" + SearchBox.Text + "%' ";
            LoadData();
        }

        private void FiltrationBox_DropDownClosed(object sender, EventArgs e)
        {
            if (FiltrationBox.SelectedIndex != 0)
                Filtration = " AND Genres.Title = '" + FiltrationBox.Text + "' ";
            else
                Filtration = "";
            LoadData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Assets.Classes.UserData.auth.Show();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost ASC ";
            LoadData();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost DESC ";
            LoadData();
        }
    }
}
