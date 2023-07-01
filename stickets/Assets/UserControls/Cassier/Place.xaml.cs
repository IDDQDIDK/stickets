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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stickets.Assets.UserControls.Cassier
{
    /// <summary>
    /// Логика взаимодействия для Place.xaml
    /// </summary>
    public partial class Place : UserControl
    {
        string ID, PlaceCost, PlaceTitle, Hall;
        bool isTaken = false;
        private void Around_MouseLeave(object sender, MouseEventArgs e)
        {
            Around.Background = BackgroundBlack.Background;
        }

        private void Around_MouseEnter(object sender, MouseEventArgs e)
        {
            Around.Background = BackgroundBrown.Background;
        }

        public Place(string ID, string Cost, string Title, string Hall, string TimetableID)
        {
            InitializeComponent();
            this.ID = ID;
            this.Title.Text = Hall + " " + Title;
            this.Cost.Text = Cost;
            PlaceCost = Cost;
            PlaceTitle = Title;
            this.Hall = Hall;
            switch (Hall)
            {
                case "Партер":
                    PlaceColor.Background = Parter.Background;
                    break;
                case "Правая ложа бенуара":
                    PlaceColor.Background = BenuarRight.Background;
                    break;
                case "Левая ложа бенуара ":
                    PlaceColor.Background = BenualLeft.Background;
                    break;
                case "Бельтаж центр":
                    PlaceColor.Background = Beltazh.Background;
                    break;
                case "Бельтаж правая ложа":
                    PlaceColor.Background = BeltazhRight.Background;
                    break;
                case "Бельтаж левая ложа":
                    PlaceColor.Background = BeltazhLeft.Background;
                    break;
                case "Центр балкона":
                    PlaceColor.Background = BalconyCentre.Background;
                    break;
                case "Правая ложа балкона":
                    PlaceColor.Background = BalconyRight.Background;
                    break;
                case "Левая ложа балкона":
                    PlaceColor.Background = BalconyLeft.Background;
                    break;
                case "Центр галереи":
                    PlaceColor.Background = GalleryCentre.Background;
                    break;
                case "Левая ложа галереи":
                    PlaceColor.Background = GalleryLeft.Background;
                    break;
                case "Правая ложа галереи":
                    PlaceColor.Background = GalleryRight.Background;
                    break;
            }
            System.Data.DataTable table = Classes.Connection.GetTable("SELECT * FROM sales WHERE ID = " + TimetableID + " AND PlaceID = " + ID);
            if (table.Rows.Count != 0)
            {
                PlaceColor.Background = BackgroundGray.Background;
                isTaken = true;
            }

        }

        private void Around_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isTaken == false)
                Classes.UserData.Add.UpdatePlace(PlaceCost, PlaceTitle, Hall, ID);
            else
                MessageBox.Show("Место занято!");
        }
    }
}
