using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Elliela2._0
{
    /// <summary>
    /// Interaction logic for detailsINFO.xaml
    /// </summary>
    public partial class detailsINFO : Window
    {
        public detailsINFO()
        {
            InitializeComponent();

        }

        private string title;
        private string year;
        private string rated;
        private string released;
        private string runtime;
        private string genre;
        private string director;
        private string writer;
        private string actors;
        private string plot;
        private string lang;
        private string country;
        private string awards;
        private string poster;
        private List<Rating> rating;
        private string metalScore;
        private string imdbRating;
        private string imdbVotes;
        private string imdbId;
        private string type;
        private string dvdRel;
        private string boxOffice;
        private string production;
        private string website;
        


        public void setData(string id) {
            string baseUri = $"http://www.omdbapi.com/?apikey=386eaee4";
            var baseIMDB = new StringBuilder(baseUri);
                baseIMDB.Append($"&i={id}");

                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(baseIMDB.ToString());
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    ImdbEntity obj = new ImdbEntity();
                    obj = oJS.Deserialize<ImdbEntity>(json);
                        if (obj.Response == "True")
                        {
                            title = obj.Title;
                            year = obj.Year;
                            rated = obj.Rated;
                            released = obj.Released;
                            runtime = obj.Runtime;
                            genre = obj.Genre;
                            director = obj.Director;
                            writer = obj.Writer;
                            actors = obj.Actors;
                            plot = obj.Plot;
                            lang = obj.Language;
                            country = obj.Country;
                            awards = obj.Awards;
                            poster = obj.Poster;
                            rating = obj.Ratings;
                            metalScore = obj.Metascore;
                            imdbRating = obj.imdbRating;
                            imdbVotes = obj.imdbVotes;
                            imdbId = obj.imdbID;
                            type = obj.Type;
                            dvdRel = obj.DVD;
                            boxOffice = obj.BoxOffice;
                            production = obj.Production;
                            website = obj.Website;

                        }
                    else
                    {
                         MessageBox.Show("Movie not Found!!!");
                       
                    }

                }

            visData();
            
        }

        public void visData() {
            posterImg.Source = new BitmapImage(new Uri(poster));
        }


        private void DetailsInfoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility=Visibility.Collapsed;
        }
    }
}
