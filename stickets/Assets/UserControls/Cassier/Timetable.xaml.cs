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

namespace stickets.Assets.UserControls.Cassier
{
    /// <summary>
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class Timetable : UserControl
    {
        string title, cost, id, time, hall;
        public Timetable(string ID, DateTime time, string title, string cost, string age, byte[] img)
        {
            InitializeComponent();

            DataTable table = Classes.Connection.GetTable("SELECT * FROM performances WHERE ID = " + ID);
            hall = table.Rows[0]["Hall"].ToString();
            DateAndTime.Text = time.ToString("dd MMM ● ddd") + " ● " + time.ToString().Split(' ')[1].Split(':')[0] + ":" + time.ToString().Split(' ')[1].Split(':')[1] + " ";
            Title.Text = title;
            Cost.Text = "От " + cost + " ₽";
            Age.Text = age;
            try
            {
                MemoryStream Stream = new MemoryStream(img);
                BitmapImage BM = new BitmapImage();
                BM.BeginInit();
                BM.StreamSource = Stream;
                BM.EndInit();
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = BM;
                Img.Background = brush;
            }
            catch { }
            this.title = title;
            this.cost = cost;
            this.id = ID;
            this.time = time.ToString();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (hall == "Большой")
            {
                Windows.Cassier.Sale.Add add = new Windows.Cassier.Sale.Add(cost, id, title, time);
                add.Show();
                Classes.UserData.cassier.Hide();
            }
            else
            {
                Windows.Cassier.Sale.AddSmall add = new Windows.Cassier.Sale.AddSmall(cost, id, title, time);
                add.Show();
                Classes.UserData.cassier.Hide();
            }
        }
    }
}
