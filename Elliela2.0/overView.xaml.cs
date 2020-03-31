using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using WinForms = System.Windows.Forms;

namespace Elliela2._0
{
    /// <summary>
    /// Interaction logic for overView.xaml
    /// </summary>
    public partial class overView : Page
    {

        private int rowid;
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
        private string imdbId;
        private string type;
        private string dvdRel;
        private string website;
        private Uri local;
        private string comment;

        private static bool play;

        private manageLocalSave manageLocalSave = new manageLocalSave();
        private List<record> records = new List<record>();
        private List<string> tempTitle = new List<string>();

        public int Rowid { get => rowid; set => rowid = value; }
        public string Type { get => type; set => type = value; }
        public string ImdbId { get => imdbId; set => imdbId = value; }
        public static bool Play { get => play; set => play = value; }
        public string Title1 { get => title; set => title = value; }
        public Uri Local { get => local; set => local = value; }

        public overView()
        {
            InitializeComponent();

            posterImg.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            yearLabel.Visibility = Visibility.Collapsed;
            ratedLabel.Visibility = Visibility.Collapsed;
            releasedLabel.Visibility = Visibility.Collapsed;
            runtimeLabel.Visibility = Visibility.Collapsed;
            genreLabel.Visibility = Visibility.Collapsed;
            directorLabel.Visibility = Visibility.Collapsed;
            writerLabel.Visibility = Visibility.Collapsed;
            actorsLabel.Visibility = Visibility.Collapsed;
            plotLabel.Visibility = Visibility.Collapsed;
            langLabel.Visibility = Visibility.Collapsed;
            countryLabel.Visibility = Visibility.Collapsed;
            awardsLabel.Visibility = Visibility.Collapsed;
            typeLabel.Visibility = Visibility.Collapsed;
            dvdLabel.Visibility = Visibility.Collapsed;
            richTextUpdater.Visibility = Visibility.Collapsed;
            commentTextBlock.Visibility = Visibility.Collapsed;
            commentUpdateButton.Visibility = Visibility.Collapsed;
            commentLabel.Visibility = Visibility.Collapsed;
            playButton.Visibility = Visibility.Collapsed;
            pathUpdateButton.Visibility = Visibility.Collapsed;
            dvdText.Visibility = Visibility.Collapsed;
            deleteFromDataBaseButton.Visibility = Visibility.Collapsed;

        }


        private void ListTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            posterImg.Visibility = Visibility.Visible;
            titleLabel.Visibility = Visibility.Visible;
            yearLabel.Visibility = Visibility.Visible;
            ratedLabel.Visibility = Visibility.Visible;
            releasedLabel.Visibility = Visibility.Visible;
            runtimeLabel.Visibility = Visibility.Visible;
            genreLabel.Visibility = Visibility.Visible;
            directorLabel.Visibility = Visibility.Visible;
            writerLabel.Visibility = Visibility.Visible;
            actorsLabel.Visibility = Visibility.Visible;
            plotLabel.Visibility = Visibility.Visible;
            langLabel.Visibility = Visibility.Visible;
            countryLabel.Visibility = Visibility.Visible;
            awardsLabel.Visibility = Visibility.Visible;
            typeLabel.Visibility = Visibility.Visible;
            dvdLabel.Visibility = Visibility.Visible;
            richTextUpdater.Visibility = Visibility.Visible;
            commentTextBlock.Visibility = Visibility.Visible;
            commentUpdateButton.Visibility = Visibility.Visible;
            commentLabel.Visibility = Visibility.Visible;
            playButton.Visibility = Visibility.Visible;
            pathUpdateButton.Visibility = Visibility.Visible; 
            deleteFromDataBaseButton.Visibility = Visibility.Visible;
            dvdText.Visibility = Visibility.Visible;

            int selected = this.listTitle.SelectedIndex;
            if (selected != -1)
            {
                if (this.typeCombo.Text.ToLower().Equals("movie"))
                {
                    setData(records[selected].Type, records[selected].ImdbId);
                }
                if (this.typeCombo.Text.ToLower().Equals("series"))
                {
                    setData(records[selected].Type, records[selected].ImdbId);
                }
                if (this.typeCombo.Text.ToLower().Equals("episode"))
                {
                    setData(records[selected].Type, records[selected].ImdbId);
                }

            }


        }

        public void setData(string type, string imdbID)
        {
            if (type.Equals("movie"))
            {
                for (int i = 0; i < manageLocalSave.SqlMovieRecords.Count; i++)
                {
                    if (manageLocalSave.SqlMovieRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = manageLocalSave.SqlMovieRecords[i].Title;
                        this.year = manageLocalSave.SqlMovieRecords[i].Year;
                        this.rated = manageLocalSave.SqlMovieRecords[i].Rated;
                        this.released = manageLocalSave.SqlMovieRecords[i].Released;
                        this.runtime = manageLocalSave.SqlMovieRecords[i].Runtime;
                        this.genre = manageLocalSave.SqlMovieRecords[i].Genre;
                        this.director = manageLocalSave.SqlMovieRecords[i].Director;
                        this.writer = manageLocalSave.SqlMovieRecords[i].Writer;
                        this.actors = manageLocalSave.SqlMovieRecords[i].Actors;
                        this.plot = manageLocalSave.SqlMovieRecords[i].Plot;
                        this.lang = manageLocalSave.SqlMovieRecords[i].Lang;
                        this.country = manageLocalSave.SqlMovieRecords[i].Country;
                        this.awards = manageLocalSave.SqlMovieRecords[i].Awards;
                        this.poster = manageLocalSave.SqlMovieRecords[i].Poster;
                        this.ImdbId = manageLocalSave.SqlMovieRecords[i].ImdbId;
                        this.Type = manageLocalSave.SqlMovieRecords[i].Type;
                        this.dvdRel = manageLocalSave.SqlMovieRecords[i].DvdRel;
                        this.website = manageLocalSave.SqlMovieRecords[i].Website;
                        this.Local = manageLocalSave.SqlMovieRecords[i].Local;
                        this.comment = manageLocalSave.SqlMovieRecords[i].Comment;
                        this.Rowid = manageLocalSave.SqlMovieRecords[i].RowID;
                    }
                }
            }
            else if (type.Equals("series"))
            {
                for (int i = 0; i < manageLocalSave.SqlSeriesRecords.Count; i++)
                {
                    if (manageLocalSave.SqlSeriesRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = manageLocalSave.SqlSeriesRecords[i].Title;
                        this.year = manageLocalSave.SqlSeriesRecords[i].Year;
                        this.rated = manageLocalSave.SqlSeriesRecords[i].Rated;
                        this.released = manageLocalSave.SqlSeriesRecords[i].Released;
                        this.runtime = manageLocalSave.SqlSeriesRecords[i].Runtime;
                        this.genre = manageLocalSave.SqlSeriesRecords[i].Genre;
                        this.director = manageLocalSave.SqlSeriesRecords[i].Director;
                        this.writer = manageLocalSave.SqlSeriesRecords[i].Writer;
                        this.actors = manageLocalSave.SqlSeriesRecords[i].Actors;
                        this.plot = manageLocalSave.SqlSeriesRecords[i].Plot;
                        this.lang = manageLocalSave.SqlSeriesRecords[i].Lang;
                        this.country = manageLocalSave.SqlSeriesRecords[i].Country;
                        this.awards = manageLocalSave.SqlSeriesRecords[i].Awards;
                        this.poster = manageLocalSave.SqlSeriesRecords[i].Poster;
                        this.ImdbId = manageLocalSave.SqlSeriesRecords[i].ImdbId;
                        this.Type = manageLocalSave.SqlSeriesRecords[i].Type;
                        this.dvdRel = manageLocalSave.SqlSeriesRecords[i].DvdRel;
                        this.website = manageLocalSave.SqlSeriesRecords[i].Website;
                        this.Local = manageLocalSave.SqlSeriesRecords[i].Local;
                        this.comment = manageLocalSave.SqlSeriesRecords[i].Comment;
                        this.Rowid = manageLocalSave.SqlSeriesRecords[i].RowID;
                    }
                }
            }
            else
            {
                for (int i = 0; i < manageLocalSave.SqlEpisodeRecords.Count; i++)
                {
                    if (manageLocalSave.SqlEpisodeRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = manageLocalSave.SqlEpisodeRecords[i].Title;
                        this.year = manageLocalSave.SqlEpisodeRecords[i].Year;
                        this.rated = manageLocalSave.SqlEpisodeRecords[i].Rated;
                        this.released = manageLocalSave.SqlEpisodeRecords[i].Released;
                        this.runtime = manageLocalSave.SqlEpisodeRecords[i].Runtime;
                        this.genre = manageLocalSave.SqlEpisodeRecords[i].Genre;
                        this.director = manageLocalSave.SqlEpisodeRecords[i].Director;
                        this.writer = manageLocalSave.SqlEpisodeRecords[i].Writer;
                        this.actors = manageLocalSave.SqlEpisodeRecords[i].Actors;
                        this.plot = manageLocalSave.SqlEpisodeRecords[i].Plot;
                        this.lang = manageLocalSave.SqlEpisodeRecords[i].Lang;
                        this.country = manageLocalSave.SqlEpisodeRecords[i].Country;
                        this.awards = manageLocalSave.SqlEpisodeRecords[i].Awards;
                        this.poster = manageLocalSave.SqlEpisodeRecords[i].Poster;
                        this.ImdbId = manageLocalSave.SqlEpisodeRecords[i].ImdbId;
                        this.Type = manageLocalSave.SqlEpisodeRecords[i].Type;
                        this.dvdRel = manageLocalSave.SqlEpisodeRecords[i].DvdRel;
                        this.website = manageLocalSave.SqlEpisodeRecords[i].Website;
                        this.Local = manageLocalSave.SqlEpisodeRecords[i].Local;
                        this.comment = manageLocalSave.SqlEpisodeRecords[i].Comment;
                        this.Rowid = manageLocalSave.SqlEpisodeRecords[i].RowID;
                    }
                }

            }


            visData();



        }

        public void visData()
        {


            if (poster.Equals("N/A"))
            {
                posterImg.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
            }
            else
            {
                posterImg.Source = new BitmapImage(new Uri(poster));
            }
            titleText.Content = this.Title1;
            yearText.Content = this.year;
            ratedText.Content = this.rated;
            releasedText.Content = this.released;
            runtimeText.Content = this.runtime;
            genreText.Content = this.genre;
            directorText.Content = this.director;
            writerText.Content = this.writer;
            actorsText.Text = this.actors;
            plotText.Text = this.plot;
            languageText.Text = this.lang;
            countryText.Content = this.country;
            awardsText.Content = this.awards;
            typeText.Content = this.Type;
            dvdText.Content = this.dvdRel;
            commentTextBlock.Text = this.comment;

        }

        private void PathUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.type.Equals("series"))
            {
                WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
                folderDialog.ShowNewFolderButton = false;
                folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                WinForms.DialogResult result = folderDialog.ShowDialog();
                if (result == WinForms.DialogResult.OK)
                    Local = new Uri(folderDialog.SelectedPath);

            }
            if (this.type.Equals("movie") || this.type.Equals("episode"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Media files (*.mp4;*.mkv;*.flc)|*.mp4;*.mkv;*.flc|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                    Local = new Uri(openFileDialog.FileName);
            }




        }

        private void CommentUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string richtext = new TextRange(richTextUpdater.Document.ContentStart, richTextUpdater.Document.ContentEnd).Text;
            this.commentTextBlock.Text = richtext;
            if (this.type.Equals("movie"))
            {
                manageLocalSave.commentUpdate(this.type, this.rowid, richtext);
            }
            else if (this.type.Equals("series"))
            {
                manageLocalSave.commentUpdate(this.type, this.rowid, richtext);
            }
            else
            {
                manageLocalSave.commentUpdate(this.type, this.rowid, richtext);
            }

        }

        private void RichTextUpdater_GotFocus(object sender, RoutedEventArgs e)
        {
            richTextUpdater.Document.Blocks.Clear();
        }

        private void DeleteFromDataBaseButton_Click(object sender, RoutedEventArgs e)
        {

            manageLocalSave.deleteFromLocal(this.type, this.rowid);

            tempTitle.RemoveAt(listTitle.SelectedIndex);
            listTitle.ItemsSource = null;
            listTitle.Items.Remove(listTitle.SelectedIndex);
            listTitle.ItemsSource = tempTitle;

            posterImg.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            yearLabel.Visibility = Visibility.Collapsed;
            ratedLabel.Visibility = Visibility.Collapsed;
            releasedLabel.Visibility = Visibility.Collapsed;
            runtimeLabel.Visibility = Visibility.Collapsed;
            genreLabel.Visibility = Visibility.Collapsed;
            directorLabel.Visibility = Visibility.Collapsed;
            writerLabel.Visibility = Visibility.Collapsed;
            actorsLabel.Visibility = Visibility.Collapsed;
            plotLabel.Visibility = Visibility.Collapsed;
            langLabel.Visibility = Visibility.Collapsed;
            countryLabel.Visibility = Visibility.Collapsed;
            awardsLabel.Visibility = Visibility.Collapsed;
            typeLabel.Visibility = Visibility.Collapsed;
            dvdLabel.Visibility = Visibility.Collapsed;
            richTextUpdater.Visibility = Visibility.Collapsed;
            commentTextBlock.Visibility = Visibility.Collapsed;
            commentUpdateButton.Visibility = Visibility.Collapsed;
            commentLabel.Visibility = Visibility.Collapsed;
            playButton.Visibility = Visibility.Collapsed;
            pathUpdateButton.Visibility = Visibility.Collapsed;
            deleteFromDataBaseButton.Visibility = Visibility.Collapsed;
        }

        private void TypeCombo_DropDownClosed(object sender, EventArgs e)
        {
            List<string> emtpy = new List<string>();
            this.listTitle.ItemsSource = null;
            this.listTitle.Items.Clear();
            tempTitle.Clear();

            if (this.typeCombo.Text.ToLower().Equals("movie"))
            {
                if (manageLocalSave.allTitle("movie") != null)
                {

                    for (int i = 0; i < manageLocalSave.SqlMovieRecords.Count; i++)
                    {
                        tempTitle.Add(manageLocalSave.SqlMovieRecords[i].Title);
                    }
                    this.listTitle.ItemsSource = tempTitle;

                    records = manageLocalSave.SqlMovieRecords;
                }
                else
                {
                    this.listTitle.ItemsSource = emtpy;

                }

            }

            if (this.typeCombo.Text.ToLower().Equals("series"))
            {
                if (manageLocalSave.allTitle("series") != null)
                {
                    tempTitle = manageLocalSave.allTitle("series");
                    this.listTitle.ItemsSource = tempTitle;
                    records = manageLocalSave.SqlSeriesRecords;
                }
                else
                {
                    this.listTitle.ItemsSource = emtpy;
                }

            }

            if (this.typeCombo.Text.ToLower().Equals("episode"))
            {
                if (manageLocalSave.allTitle("episode") != null)
                {
                    this.listTitle.ItemsSource = manageLocalSave.allTitle("episode");
                    records = manageLocalSave.SqlEpisodeRecords;
                }
                else
                {
                    this.listTitle.ItemsSource = emtpy;
                }

            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            localDBBrowser.Path = this.local;
            localDBBrowser.Play = true;
            if (this.type.Equals("series"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select Episode";
                openFileDialog.Filter = "Media files (*.mp4;*.mkv;*.flc)|*.mp4;*.mkv;*.flc|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                    local = new Uri(openFileDialog.FileName);
            }

        }

    }
}
