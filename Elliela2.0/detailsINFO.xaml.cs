using Microsoft.Win32;
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
using WinForms = System.Windows.Forms;

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

        private Uri local;
        private string comment;


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
                    imdbId = obj.imdbID;
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
                    System.Windows.MessageBox.Show("Movie not Found!!!");
                       
                    }

                }

            visData();
            
        }

        public void visData() {
            if (poster.Equals("N/A"))
            {
                posterImg.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
            }
            else
            {
                posterImg.Source = new BitmapImage(new Uri(poster));
            }
            imdbidText.Content = this.imdbId;
            titleText.Content = this.title;
            yearText.Content = this.year;
            ratedText.Content = this.rated;
            releasedText.Content = this.released;
            runtimeText.Content = this.runtime;
            genreText.Content = this.genre;
            directorText.Content = this.director;
            writerText.Content = this.writer;
            actorsText.Text = this.actors;
            plotText.Text = this.plot;
            languageText.Content = this.lang;
            countryText.Content = this.country;
            awardsText.Content = this.awards;
            metalscoreText.Content = this.metalScore;
            imdbRatingText.Content = this.imdbRating;
            imdbvotesText.Content = this.imdbVotes;
            typeText.Content = this.type;
            dvdText.Content = this.dvdRel;
            boxOfficeText.Content = this.boxOffice;
            productionText.Content = this.production;
            webSiteText.Content = this.website;


        }


        private void DetailsInfoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility=Visibility.Collapsed;
        }

        private void AddLoc_Click(object sender, RoutedEventArgs e)
        {
            if (this.type.Equals("series"))
            {
                WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
                folderDialog.ShowNewFolderButton = false;
                folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                WinForms.DialogResult result = folderDialog.ShowDialog();
                if (result == WinForms.DialogResult.OK)
                    local = new Uri(folderDialog.SelectedPath);

            }
            if (this.type.Equals("movie"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Media files (*.mp4;*.mkv;*.flc)|*.mp4;*.mkv;*.flc|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                    local = new Uri(openFileDialog.FileName);
            }

            try
            {
                manageLocalSave localMan = new manageLocalSave();
                localMan.tableTypeSelect(this.title,this.year,this.rated,this.released,this.runtime,this.genre,this.director,this.writer,this.actors,this.plot,this.lang,this.country,this.awards,this.poster,this.imdbId,this.type,this.dvdRel,this.website,this.comment,this.local);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled Error");
                MessageBox.Show("The program determinate!");
                System.Windows.Application.Current.Shutdown();
            }


        }
        
        private void CommentText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string richtext = new TextRange(commentText.Document.ContentStart, commentText.Document.ContentEnd).Text;
            this.comment = richtext;
        }
    }
}
