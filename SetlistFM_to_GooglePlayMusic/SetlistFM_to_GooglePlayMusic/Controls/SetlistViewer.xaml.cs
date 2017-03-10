using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fm.Setlist.Api.Model;

namespace SetlistFM_to_GooglePlayMusic.Controls
{
    /// <summary>
    /// Interaction logic for SetlistViewer.xaml
    /// </summary>
    public partial class SetlistViewer : UserControl
    {
        public SetlistViewer()
        {
            InitializeComponent();

            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Num";
            c1.Binding = new Binding("Num");
            c1.Width = 110;
            dataGrid_log.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Start";
            c2.Width = 110;
            c2.Binding = new Binding("Start");
            dataGrid_log.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Finich";
            c3.Width = 110;
            c3.Binding = new Binding("Finich");
            dataGrid_log.Columns.Add(c3);

            dataGrid_log.Items.Add(new Setlist() { EventDate = "Prueba", Tour = "2012, 8, 15", Venue = "2012, 9, 15" });
        }
    }
}