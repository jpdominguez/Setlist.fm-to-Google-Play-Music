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
using System.Threading;

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
        }

        private void button_SearchArtists_Click(object sender, RoutedEventArgs e)
        {
            listBox_Artists.Items.Clear();

            Task.Factory.StartNew(() => fillTB());

        }

        private void fillTB()
        {
            this.Dispatcher.Invoke(() =>
            {
                List<Artist> bands = searchArtistByName(tbox_ArtistName.Text.Replace(' ', '-'));

                foreach (Artist band in bands)
                {
                    //tblock_Artists.Text += band.Name;
                    if (bands.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(band.Disambiguation))
                        {
                            //tblock_Artists.Text += " (" + band.Disambiguation + ")\n";
                            listBox_Artists.Items.Add(band.Name + " (" + band.Disambiguation + ")");
                        }
                        else
                        {
                            //tblock_Artists.Text += "\n";
                            listBox_Artists.Items.Add(band.Name);
                        }
                    }
                }
            });
        }


        private List<Artist> searchArtistByName(string artistName)
        {
            List<Artist> artists = new List<Artist>();

            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/artists?artistName=" + artistName);

            //Console.WriteLine(uri.Query);
            XmlSerializer s = new XmlSerializer(typeof(Artists));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);
            Artists im = (Artists)s.Deserialize(r);

            artists.AddRange(im.List);

            return artists;
        }


        private List<Setlist> searchSetlistsByArtistName(string artistName, int pageNumber)  //each page == 20 results
        {
            List<Setlist> setlists = new List<Setlist>();

            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/setlists?p=" + pageNumber.ToString() + "&artistName=" + artistName);

            //Console.WriteLine(uri.Query);
            XmlSerializer s = new XmlSerializer(typeof(Setlists));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);
            Setlists sets = (Setlists)s.Deserialize(r);

            setlists.AddRange(sets.List.FindAll(x => x.Sets.Count > 0));  //Before adding the setlists to the list, check if the setlist has at least one set.

            return setlists;
        }


        private List<Song> songsFromSetlist(Setlist sl)
        {
            List<Song> songs = new List<Song>();

            foreach (Set s in sl.Sets)
            {
                songs.AddRange(s.Songs);
            }
            return songs;
        }

        private void tbox_ArtistName_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
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
            */

        }

        private void button_displaySetlists_Click(object sender, RoutedEventArgs e)
        {
            List<Setlist> setlists;
            if (listBox_Artists.SelectedIndex != -1)
            {
                setlists = searchSetlistsByArtistName(listBox_Artists.SelectedItem.ToString(), 1);
            }
        }

        private void tbox_ArtistName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_SearchArtists_Click(this, null);
            }
        }
    }
}