using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Perfomance.xaml
    /// </summary>
    public partial class Perfomance : UserControl
    {
        string ID;
        byte[] Image;
        public Perfomance(string ID, string Title, string Specification, object Photo, string Duration, string Cost, string GenreID, string AgeRestrictionID, string IsAvalible)
        {
            InitializeComponent();
            this.ID = ID;
            this.Title.Text = Title;
            this.Specification.Text = Specification;
            this.Cost.Text = Cost;
            this.Duration.Text = Duration;
            try
            {
                MemoryStream Stream = new MemoryStream((byte[])Photo);
                BitmapImage BM = new BitmapImage();
                BM.BeginInit();
                BM.StreamSource = Stream;
                BM.EndInit();
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = BM;
                brush.Stretch = Stretch.Uniform;
                Img.Background = brush;
                Hint.Visibility = Visibility.Hidden;
            }
            catch { }
            Genre.SelectedIndex = Convert.ToInt32(GenreID) - 1;
            Age.SelectedIndex = Convert.ToInt32(AgeRestrictionID) - 1;
            if (IsAvalible == "Не ставится")
                Status.Visibility = Visibility.Visible;

            DataTable data = Classes.Connection.GetTable("SELECT * FROM Genres");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Genre.Items.Add(data.Rows[i]["Title"]);
            }
            data = Classes.Connection.GetTable("SELECT * FROM AgeRestrictions");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Age.Items.Add(data.Rows[i]["Title"]);
            }
        }

        private void Img_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                System.Drawing.Image image = System.Drawing.Image.FromFile(files[0]);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Image = ms.ToArray();
                try
                {
                    BitmapImage BM = new BitmapImage();
                    BM.BeginInit();
                    BM.StreamSource = ms;
                    BM.EndInit();
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = BM;
                    Img.Background = brush;
                }
                catch { }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Text.Length != 0 && Specification.Text.Length != 0 && Duration.Text.Length != 0 && Cost.Text.Length != 0 && Genre.SelectedItem != null && Age.SelectedItem != null)
            {
                if (Hall.Text == "Большой")
                {
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE performances SET Title = '" + Title.Text + "', Duration = '" + Duration.Text + "', Specification = '" + Specification.Text + "', Cost = '" + Cost.Text + "', GenreID = '" + (Genre.SelectedIndex + 1) + "', AgeRestrictionID = '" + (Age.SelectedIndex + 1) + "', Hall = 'Большой' WHERE ID = " + ID, Classes.Connection.con);
                    command.ExecuteNonQuery();
                }
                else if (Hall.Text == "Малый")
                {
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE performances SET Title = '" + Title.Text + "', Duration = '" + Duration.Text + "', Specification = '" + Specification.Text + "', Cost = '" + Cost.Text + "', GenreID = '" + (Genre.SelectedIndex + 1) + "', AgeRestrictionID = '" + (Age.SelectedIndex + 1) + "', Hall = 'Малый' WHERE ID = " + ID, Classes.Connection.con);
                    command.ExecuteNonQuery();
                }
            }
            Classes.UserData.perfomances.LoadData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlCommand command;
            if (Status.IsVisible)
                command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Perfomances SET IsAvalible = 'Ставится' WHERE ID = " + ID, Classes.Connection.con);
            else
                command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Perfomances SET IsAvalible = 'Не ставится' WHERE ID = " + ID, Classes.Connection.con);
            command.ExecuteNonQuery();
            Classes.UserData.perfomances.LoadData();
        }
    }
}
