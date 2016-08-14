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

            /*
            //read a resource from a REST url
            //API KEY Uri uri = new Uri("d00ca8ce - 14cd - 4089 - a542 - 8225974c0188");
            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/artist/ca891d65-d9b0-4258-89f7-e6ba29d83767");
            //Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/artists?artistMbid=ca891d65-d9b0-4258-89f7-e6ba29d83767");
            XmlSerializer s = new XmlSerializer(typeof(Artist));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);

            Artist im = (Artist)s.Deserialize(r);

            //handle the result as needed...
            */


        }

        private void button_SearchArtists_Click(object sender, RoutedEventArgs e)
        {
            tblock_Artists.Text = "";

            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/artists?artistName=" + tbox_ArtistName.Text.Replace(' ', '-'));

            Console.WriteLine(uri.Query);
            XmlSerializer s = new XmlSerializer(typeof(Artists));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);
            Artists im = (Artists)s.Deserialize(r);


            foreach (Artist band in im.List)
            {
                tblock_Artists.Text += band.Name;
                if (im.List.Count > 1)
                {
                    tblock_Artists.Text += " \\\\\\ " + band.Disambiguation + "\n";
                }
            }
        }

        private void tbox_ArtistName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tblock_Artists.Text = "";

                Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/artists?artistName=" + tbox_ArtistName.Text.Replace(' ', '-'));

                Console.WriteLine(uri.Query);
                XmlSerializer s = new XmlSerializer(typeof(Artists));

                //Create the request object
                WebRequest req = WebRequest.Create(uri);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                TextReader r = new StreamReader(stream);
                Artists im = (Artists)s.Deserialize(r);


                foreach (Artist band in im.List)
                {
                    tblock_Artists.Text += band.Name;
                    if (im.List.Count > 1)
                    {
                        tblock_Artists.Text += " \\\\\\ " + band.Disambiguation + "\n";
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
            
        }
    }
}
