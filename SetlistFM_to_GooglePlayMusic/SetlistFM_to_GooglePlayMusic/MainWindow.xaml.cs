﻿using System;
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

            /*
            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/artists?artistName=" + tbox_ArtistName.Text.Replace(' ', '-'));

            Console.WriteLine(uri.Query);
            XmlSerializer s = new XmlSerializer(typeof(Artists));

            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            TextReader r = new StreamReader(stream);
            Artists im = (Artists)s.Deserialize(r);
            */

            //foreach (Artist band in im.List)

            List<Artist> bands = searchArtistByName(tbox_ArtistName.Text.Replace(' ', '-'));
            foreach (Artist band in bands)
            {
                tblock_Artists.Text += band.Name;
                //if (im.List.Count > 1)
                if(bands.Count > 1)
                {
                    if (!String.IsNullOrEmpty(band.Disambiguation))
                    {
                        tblock_Artists.Text += " (" + band.Disambiguation + ")\n";
                    }
                    else
                    {
                        tblock_Artists.Text += "\n";
                    }
                }
            }

            List<Setlist> setlists = searchSetlistsByArtistName(tbox_ArtistName.Text, 3);
            List<Song> songs = songsFromSetlist(setlists[0]);
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

            Uri uri = new Uri("http://api.setlist.fm/rest/0.1/search/setlists?p="+pageNumber.ToString()+"&artistName=" + artistName);

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

            foreach(Set s in sl.Sets)
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
    }
}
