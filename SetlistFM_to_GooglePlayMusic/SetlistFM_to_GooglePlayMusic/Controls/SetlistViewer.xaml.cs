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

            /*
            DataGridTextColumn c1 = new DataGridTextColumn
            {
                Header = "EventDate",
                Binding = new Binding("EventDate"),
                Width = 110
            };
            dataGrid_log.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn()
            {
                Header = "Tour",
                Width = 110,
                Binding = new Binding("Tour")
            };
            dataGrid_log.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();

            dataGrid_log.Items.Add(new Setlist() {EventDate = "Prueba", Tour = "2012, 8, 15"});
            */
        }
    }
}