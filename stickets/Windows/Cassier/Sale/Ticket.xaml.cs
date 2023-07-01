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

namespace stickets.Windows.Cassier.Sale
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Window
    {
        public Ticket(string Title, string Hall, string Place, string WhenStarts, string Cost, string SmallBig)
        {
            InitializeComponent();
            this.Title.Text = Title.Split(':')[1];
            this.Hall.Text = Hall;
            this.Place.Text = Place.Split(' ')[2];
            this.Row.Text = Place.Split(' ')[0];
            this.WhenDate.Text = WhenStarts.Split(' ')[0];
            this.WhenTime.Text = WhenStarts.Split(' ')[1];
            this.Price.Text = Cost;
            HallRip.Text = Hall;
            PlaceRip.Text = Place.Split(' ')[2];
            RowRip.Text = Place.Split(' ')[0];
            TitleRip.Text = Title.Split(':')[1];
            this.SmallBig.Text = SmallBig;

            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
                p.PrintVisual(TicketSP, "Печать");
        }
    }
}
