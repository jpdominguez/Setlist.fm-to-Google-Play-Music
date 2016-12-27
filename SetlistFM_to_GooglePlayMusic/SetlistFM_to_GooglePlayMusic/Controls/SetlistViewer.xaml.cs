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

            var items = new List<int>();
            items.Add(4);
            items.Add(2);
            items.Add(3);


            dataGrid_log.ItemsSource = items;
        }
    }
}