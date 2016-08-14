using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml.Serialization;
using Fm.Setlist.Api.Model;

namespace SetlistFM_to_GooglePlayMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //read a resource from a REST url
            //Uri uri = new Uri("d00ca8ce - 14cd - 4089 - a542 - 8225974c0188");
            Uri uri = new Uri("ca891d65 - d9b0 - 4258 - 89f7 - e6ba29d83767");

            XmlSerializer s = new XmlSerializer(typeof(Setlist));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);

            Setlist order = (Setlist)s.Deserialize(r);

            //handle the result as needed...
        }
    }
}
