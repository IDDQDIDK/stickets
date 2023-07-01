using Org.BouncyCastle.Asn1.Cmp;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace stickets.Windows.Manager.Performances
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Window
    {
        string Search = " WHERE Performances.Title LIKE '%%' ", Filtration, Sort;
        int Pages, Start = 0, CurrentPage = 0;
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = " WHERE Performances.Title LIKE '%" + SearchBox.Text + "%' ";
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

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost ";
            LoadData();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            Sort = " ORDER BY Cost DESC ";
            LoadData();
        }

        public View()
        {
            InitializeComponent();
            Assets.Classes.UserData.perfomances = this;
            DataTable data = Assets.Classes.Connection.GetTable("SELECT * FROM Genres");
            Pages = data.Rows.Count / 2;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                FiltrationBox.Items.Add(data.Rows[i][1].ToString());
            }
            LoadData();
        }
        
        public void LoadData()
        {
            PerfomancesBox.Children.Clear();
            PerfomancesBox.Children.Add(new Assets.UserControls.AddPerfomance());
            DataTable data = Assets.Classes.Connection.GetTable("SELECT * FROM performances JOIN Genres ON Genres.ID = GenreID " + Search + Filtration + Sort);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                PerfomancesBox.Children.Add(new Assets.UserControls.Perfomance(data.Rows[i]["ID"].ToString(), data.Rows[i]["Title"].ToString(), data.Rows[i]["Specification"].ToString(), data.Rows[i]["Photo"], data.Rows[i]["Duration"].ToString(), data.Rows[i]["Cost"].ToString(), data.Rows[i]["GenreID"].ToString(), data.Rows[i]["AgeRestrictionID"].ToString(), data.Rows[i]["IsAvalible"].ToString()));
            }
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
    }
}
