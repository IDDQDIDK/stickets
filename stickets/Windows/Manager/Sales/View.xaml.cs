using Microsoft.Office.Interop.Excel;
using stickets.Assets.UserControls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
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
namespace stickets.Windows.Manager.Sales
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : System.Windows.Window
    {
        public View()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (BeginDate.DisplayDate != null && EndDate.DisplayDate != null)
            {
                System.Data.DataTable table = Assets.Classes.Connection.GetTable("SELECT * FROM salereport WHERE WhenSaled >= '" + Convert.ToDateTime(BeginDate.Text).ToString("yyyy-MM-dd") + "' AND WhenSaled <= '" + Convert.ToDateTime(EndDate.Text).ToString("yyyy-MM-dd") + "'");

                string Dir = System.IO.Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
                string Exe_Directory = Dir.Substring(0, Dir.IndexOf(@"\bin"));
                var Excel = new Microsoft.Office.Interop.Excel.Application();
                var xlWB = Excel.Workbooks.Open(Exe_Directory + @"\Assets\Report\Отчёт.xlsx");
                var xlSht = xlWB.Worksheets[1];
                xlSht.Cells[1, 3] = DateTime.Now.ToShortDateString();
                xlSht.Cells[3, 3] = BeginDate.DisplayDate;
                xlSht.Cells[3, 5] = EndDate.DisplayDate;
                xlSht.Columns[2].ColumnWidth = 17.45;
                xlSht.Columns[3].ColumnWidth = 20.45;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    xlSht.Cells[i + 14, 2] = table.Rows[i]["Perfomance"];
                    xlSht.Cells[i + 14, 3] = table.Rows[i]["Place"];
                    xlSht.Cells[i + 14, 4] = (int)table.Rows[i]["HallCost"] + (int)table.Rows[i]["PerfomanceCost"];
                    xlSht.Cells[i + 14, 5] = table.Rows[i]["Second_Name"] + " " + table.Rows[i]["First_Name"] + " " + table.Rows[i]["Patronymic"];
                    xlSht.Cells[i + 14, 6] = table.Rows[i]["WhenSaled"];

                    xlSht.Cells[i + 14, 2].Borders.LineStyle = XlLineStyle.xlContinuous;
                    xlSht.Cells[i + 14, 3].Borders.LineStyle = XlLineStyle.xlContinuous;
                    xlSht.Cells[i + 14, 4].Borders.LineStyle = XlLineStyle.xlContinuous;
                    xlSht.Cells[i + 14, 5].Borders.LineStyle = XlLineStyle.xlContinuous;
                    xlSht.Cells[i + 14, 6].Borders.LineStyle = XlLineStyle.xlContinuous;
                }

                xlSht.Cells[table.Rows.Count + 15, 4] = DateTime.Now;
                xlSht.Cells[table.Rows.Count + 15, 6] = Assets.Classes.UserData.Name;
                xlSht.Cells[table.Rows.Count + 17, 6] = Assets.Classes.UserData.Role;

                xlSht.Cells[table.Rows.Count + 15, 4].Borders.LineStyle = XlLineStyle.xlContinuous;
                xlSht.Cells[table.Rows.Count + 15, 6].Borders.LineStyle = XlLineStyle.xlContinuous;
                xlSht.Cells[table.Rows.Count + 17, 6].Borders.LineStyle = XlLineStyle.xlContinuous;

                Excel.Visible = true;

            }
            else
                MessageBox.Show("Вы должны выбрать полный промежуток времени!");
        }

        private void BeginDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDate.DisplayDateStart = BeginDate.DisplayDate;
            EndDate.IsEnabled = true;
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Print.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
