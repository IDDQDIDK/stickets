using Microsoft.Win32;
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
    /// Логика взаимодействия для AddPerfomance.xaml
    /// </summary>
    public partial class AddPerfomance : UserControl
    {
        string ID;
        byte[] Image;
        public AddPerfomance()
        {
            InitializeComponent();
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
        OpenFileDialog OFD = new OpenFileDialog();
        private void Img_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                MessageBox.Show(files[0]);
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
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO performances (Title, Duration, Specification, Cost, GenreID, AgeRestrictionID, Photo, IsAvalible, Hall) VALUES ('" + Title.Text + "', '" + Duration.Text + "', '" + Specification.Text + "', '" + Cost.Text + "', '" + (Genre.SelectedIndex + 1) + "', '" + (Age.SelectedIndex + 1) + "', @Image, 'Ставится', 'Большой') ", Classes.Connection.con);
                    MySql.Data.MySqlClient.MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
                    param.ParameterName = "Image";
                    param.Value = Image;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                    Classes.UserData.perfomances.LoadData();
                }
                else if (Hall.Text == "Малый")
                {
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO performances (Title, Duration, Specification, Cost, GenreID, AgeRestrictionID, Photo, IsAvalible, Hall) VALUES ('" + Title.Text + "', '" + Duration.Text + "', '" + Specification.Text + "', '" + Cost.Text + "', '" + (Genre.SelectedIndex + 1) + "', '" + (Age.SelectedIndex + 1) + "', @Image, 'Ставится', 'Малый') ", Classes.Connection.con);
                    MySql.Data.MySqlClient.MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
                    param.ParameterName = "Image";
                    param.Value = Image;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                    Classes.UserData.perfomances.LoadData();
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }

    }
}
