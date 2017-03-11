using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetlistFM_to_GooglePlayMusic.Assets
{
    public class APICalls
    {
        private static string SearchSetlist = "http://api.setlist.fm/rest/0.1/search/setlists?p=";
        private static string SearchArtist = "http://api.setlist.fm/rest/0.1/search/artists?artistName=";

        public static Uri SearchSetlistByArtistAndPageNumber(string artistName, int pageNumber)
        {
            return new Uri(SearchSetlist + pageNumber.ToString() + "&artistName=" + artistName);
        }

        public static Uri SearchArtistByName(string artistName)
        {
            return new Uri(SearchArtist + artistName);
        }
    }
}