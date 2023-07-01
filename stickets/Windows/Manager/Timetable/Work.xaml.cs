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

namespace stickets.Windows.Manager.Timetable
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work : Window
    {
        string Search = " WHERE performances.Title LIKE '%%'", Filtration, Sort;
        int Pages, Start = 0, CurrentPage = 0;
        public Work()
        {
            InitializeComponent();
            FiltrationBox.Items.Add("Все жанры");
            Assets.Classes.UserData.timetable = this;

            DataTable data = Assets.Classes.Connection.GetTable("SELECT * FROM Genres");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                FiltrationBox.Items.Add(data.Rows[i][1].ToString());
            }
            LoadData();
        }
        public void LoadData()
        {
            TimetableBox.Children.Clear();
            TimetableBox.Children.Add(new Assets.UserControls.AddTimetable());
            DataTable table = Assets.Classes.Connection.GetTable("SELECT * FROM Timetable JOIN performances ON PerfomanceID = performances.ID JOIN Genres ON GenreID = Genres.ID " + Search + Filtration + Sort);
            for (int i = Start; i < table.Rows.Count; i++)
                TimetableBox.Children.Add(new Assets.UserControls.Timetable(table.Rows[i]["ID"].ToString(), table.Rows[i]["WhenStarts"].ToString(), table.Rows[i]["PerfomanceID"].ToString(), table.Rows[i]["IsDone"].ToString()));
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = " WHERE performances.Title LIKE '%" + SearchBox.Text + "%'";
            LoadData();
        }

        private void FiltrationBox_DropDownClosed(object sender, EventArgs e)
        {
            if (FiltrationBox.SelectedIndex != 0)
            {
                Filtration = " AND Genres.Title = '" + FiltrationBox.Text + "' ";
            }
            else
                Filtration = "";
            LoadData();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage - 1 < 0)
                MessageBox.Show("Вы на первой странице!");
            else
            {
                Start -= 2;
                LoadData();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage + 1 > Pages)
                MessageBox.Show("Вы на последней странице!");
            else
            {
                Start += 2;
                LoadData();
            }
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost ASC";
            LoadData();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost ASC DESC";
            LoadData();
        }
    }
}
