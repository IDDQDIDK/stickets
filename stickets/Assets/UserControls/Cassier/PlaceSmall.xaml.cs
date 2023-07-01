using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
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
    /// Логика взаимодействия для PlaceSmall.xaml
    /// </summary>
    public partial class PlaceSmall : UserControl
    {
        string ID, PlaceCost, PlaceTitle, Hall;
        bool isTaken = false;
        public PlaceSmall(string ID, string Cost, string Title, string Hall, string TimetableID)
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
                case "Передняя часть":
                    PlaceColor.Background = LimeBG.Background;
                    break;
                case "Малая передняя часть":
                    PlaceColor.Background = YellowBG.Background;
                    break;
                case "Средняя часть":
                    PlaceColor.Background = OrangeBG.Background;
                    break;
                case "Задняя часть":
                    PlaceColor.Background = RedBG.Background;
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
                Classes.UserData.AddSmall.UpdatePlace(PlaceCost, PlaceTitle, Hall, ID);
            else
                MessageBox.Show("Место занято!");
        }

        private void Around_MouseLeave(object sender, MouseEventArgs e)
        {
            Around.Background = BackgroundBlack.Background;
        }

        private void Around_MouseEnter(object sender, MouseEventArgs e)
        {
            Around.Background = BackgroundBrown.Background;
        }
    }
}
