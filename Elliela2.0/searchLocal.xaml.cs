using Microsoft.Win32;
using System;
using System.Collections;
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
    /// Interaction logic for details.xaml
    /// </summary>
    public partial class searchLocal : Page
    {
        private static manageLocalSave localDB = new manageLocalSave();
        private List<string> selectFilterBase = new List<string>();
        private List<string> tempOptionList = new List<string>();
        private List<string> tempParameterList = new List<string>();
        private List<string> temp = new List<string>();
        private List<string> titles = new List<string>();
        private List<string> years = new List<string>();
        private List<string> rateds = new List<string>();
        private List<string> releaseds = new List<string>();
        private List<string> runtimes = new List<string>();
        private List<string> genres = new List<string>();
        private List<string> directors = new List<string>();
        private List<string> writers = new List<string>();
        private List<string> actorss = new List<string>();
        private List<string> languages = new List<string>();
        private List<string> countrys = new List<string>();
        private List<string> awards = new List<string>();
        private List<string> types = new List<string>();

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
        private string awardsS;
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
        private static List<record> tempRecords = new List<record>();


        public int Rowid { get => rowid; set => rowid = value; }
        public string Type { get => type; set => type = value; }
        public string ImdbId { get => imdbId; set => imdbId = value; }
        public static bool Play { get => play; set => play = value; }
        public string Title1 { get => title; set => title = value; }
        public Uri Local { get => local; set => local = value; }

        public searchLocal()
        {
            InitializeComponent();
            localDB.ReadDataLocal();
            selectFilterBase.Add("title");
            selectFilterBase.Add("year");
            selectFilterBase.Add("rated");
            selectFilterBase.Add("released");
            selectFilterBase.Add("runtime");
            selectFilterBase.Add("genre");
            selectFilterBase.Add("director");
            selectFilterBase.Add("writer");
            selectFilterBase.Add("actors");
            selectFilterBase.Add("language");
            selectFilterBase.Add("country");
            selectFilterBase.Add("awards");
            selectFilterBase.Add("Type");

            this.filterTypeList.ItemsSource = selectFilterBase;
            
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

        private void FilterTypeList_DropDownClosed(object sender, EventArgs e)
        {
            this.optionList.ItemsSource = null;
            tempOptionList = null;

            if (filterTypeList.SelectedIndex >= 0 )
            {

                if (selectFilterBase[filterTypeList.SelectedIndex].Equals("title"))
                {
                    tempOptionList = localDB.allTitle();
                    for (int i = 0; i < localDB.allTitle().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                    
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("year"))
                {
                    tempOptionList = localDB.allYear();
                    for (int i = 0; i < localDB.allYear().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("rated"))
                {
                    tempOptionList = localDB.allRated();
                    for (int i = 0; i < localDB.allRated().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                    
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("released"))
                {
                    tempOptionList = localDB.allReleased();
                    for (int i = 0; i < localDB.allReleased().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("runtime"))
                {
                    
                    tempOptionList = localDB.allRuntime();
                    for (int i = 0; i < localDB.allRuntime().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }

                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("genre"))
                {
                   
                    tempOptionList = localDB.allGenre();
                    for (int i = 0; i < localDB.allGenre().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("director"))
                {
                    tempOptionList = localDB.allDirector();
                    for (int i = 0; i < localDB.allDirector().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("writer"))
                {

                    tempOptionList = localDB.allWriter();
                    for (int i = 0; i < localDB.allWriter().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("actors"))
                {
                    tempOptionList = localDB.allActors();
                    for (int i = 0; i < localDB.allActors().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("language"))
                {
                    tempOptionList = localDB.allLang();
                    for (int i = 0; i < localDB.allLang().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("country"))
                {
                    tempOptionList = localDB.allCountry();
                    for (int i = 0; i < localDB.allCountry().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }

                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("awards"))
                {
                    tempOptionList = localDB.allAwards();
                    for (int i = 0; i < localDB.allAwards().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
                else if (selectFilterBase[filterTypeList.SelectedIndex].Equals("Type"))
                {
                    tempOptionList = localDB.allType();
                    for (int i = 0; i < localDB.allType().Count; i++)
                    {
                        this.optionList.Items.Add(tempOptionList[i]);
                    }
                }
            }

        }

        private void AddFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (optionList.SelectedItem!=null)
            {
                foreach (var item in new ArrayList(optionList.SelectedItems))
                {
                    optionList.Items.Remove(item);
                    ParameterList.Items.Add(item);

                    if (filterTypeList.SelectedItem.Equals("title"))
                    {
                        titles.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("year"))
                    {
                        years.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("rated"))
                    {
                        rateds.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("released"))
                    {
                        releaseds.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("runtime"))
                    {
                        runtimes.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("genre"))
                    {
                        genres.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("director"))
                    {
                        directors.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("writer"))
                    {
                        writers.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("actors"))
                    {
                        actorss.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("language"))
                    {
                        languages.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("country"))
                    {
                        countrys.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("awards"))
                    {
                        awards.Add((string)item);
                    }
                    if (filterTypeList.SelectedItem.Equals("type"))
                    {
                        types.Add((string)item);
                    }
                }
            }

        }

        private void DeleteParameterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParameterList.SelectedItem != null)
            {
                foreach (var item in new ArrayList(ParameterList.SelectedItems))
                {
                   
                    for (int i = 0; i < titles.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(titles[i]))
                        {
                            titles.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < years.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(years[i]))
                        {
                            years.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < rateds.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(rateds[i]))
                        {
                            rateds.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < releaseds.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(releaseds[i]))
                        {
                            releaseds.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < runtimes.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(runtimes[i]))
                        {
                            runtimes.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < genres.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(genres[i]))
                        {
                            genres.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < directors.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(directors[i]))
                        {
                            directors.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < writers.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(writers[i]))
                        {
                            writers.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < actorss.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(actorss[i]))
                        {
                            actorss.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < languages.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(languages[i]))
                        {
                            languages.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < countrys.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(countrys[i]))
                        {
                            countrys.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < awards.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(awards[i]))
                        {
                            awards.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < types.Count; i++)
                    {
                        if (ParameterList.SelectedItem.Equals(types[i]))
                        {
                            types.RemoveAt(i);
                        }
                    }
                    ParameterList.Items.Remove(item);
                    optionList.Items.Add(item);
                }

            }
                

        }

        private void ViewResultButton_Click(object sender, RoutedEventArgs e)
        {
            this.resultlistTitle.Items.Clear();
            tempRecords=localDB.localSearch(titles, years, rateds, releaseds, runtimes, genres, directors, writers, actorss, languages, countrys, types,awards);
            if (tempRecords != null)
            {
                for (int i = 0; i < tempRecords.Count; i++)
                {
                    this.resultlistTitle.Items.Add(tempRecords[i].Title);
                }

                this.searchForLabel.Visibility = Visibility.Hidden;
                this.filterTypeList.Visibility = Visibility.Hidden;
                this.optionList.Visibility = Visibility.Hidden;
                this.ParameterList.Visibility = Visibility.Hidden;
                this.addFilterButton.Visibility = Visibility.Hidden;
                this.deleteParameterButton.Visibility = Visibility.Hidden;
                this.viewResultButton.Visibility = Visibility.Hidden;

                this.posterImg.Visibility = Visibility.Visible;

                this.imdbidLabel.Visibility = Visibility.Visible;
                this.imdbidText.Visibility = Visibility.Visible;
                this.titleLabel.Visibility = Visibility.Visible;
                this.yearLabel.Visibility = Visibility.Visible;
                this.ratedLabel.Visibility = Visibility.Visible;
                this.releasedLabel.Visibility = Visibility.Visible;
                this.runtimeLabel.Visibility = Visibility.Visible;
                this.genreLabel.Visibility = Visibility.Visible;
                this.directorLabel.Visibility = Visibility.Visible;
                this.writerLabel.Visibility = Visibility.Visible;
                this.actorsLabel.Visibility = Visibility.Visible;
                this.plotLabel.Visibility = Visibility.Visible;
                this.langLabel.Visibility = Visibility.Visible;
                this.countryLabel.Visibility = Visibility.Visible;
                this.awardsLabel.Visibility = Visibility.Visible;
                this.typeLabel.Visibility = Visibility.Visible;
                this.dvdLabel.Visibility = Visibility.Visible;
                this.richTextUpdater.Visibility = Visibility.Visible;
                this.commentTextBlock.Visibility = Visibility.Visible;
                this.commentUpdateButton.Visibility = Visibility.Visible;
                this.commentLabel.Visibility = Visibility.Visible;
                this.playButton.Visibility = Visibility.Visible;
                this.pathUpdateButton.Visibility = Visibility.Visible;
                this.deleteFromDataBaseButton.Visibility = Visibility.Visible;
                this.resultlistTitle.Visibility = Visibility.Visible;
                this.clearResult.Visibility = Visibility.Visible;
                this.dvdText.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("No result");
            }



        }

        private void ClearResult_Click(object sender, RoutedEventArgs e)
        {
            this.resultlistTitle.Items.Clear();
            this.searchForLabel.Visibility = Visibility.Visible;
            this.filterTypeList.Visibility = Visibility.Visible;
            this.optionList.Visibility = Visibility.Visible;
            this.ParameterList.Visibility = Visibility.Visible;
            this.addFilterButton.Visibility = Visibility.Visible;
            this.deleteParameterButton.Visibility = Visibility.Visible;
            this.viewResultButton.Visibility = Visibility.Visible;

            this.posterImg.Visibility = Visibility.Hidden;
            this.imdbidLabel.Visibility = Visibility.Hidden;
            this.imdbidText.Visibility = Visibility.Hidden;
            this.titleLabel.Visibility = Visibility.Hidden;
            this.titleText.Visibility = Visibility.Hidden;
            this.yearLabel.Visibility = Visibility.Hidden;
            this.yearText.Visibility = Visibility.Hidden;
            this.ratedLabel.Visibility = Visibility.Hidden;
            this.ratedText.Visibility = Visibility.Hidden;
            this.releasedLabel.Visibility = Visibility.Hidden;
            this.releasedText.Visibility = Visibility.Hidden;
            this.runtimeLabel.Visibility = Visibility.Hidden;
            this.runtimeText.Visibility = Visibility.Hidden;
            this.genreLabel.Visibility = Visibility.Hidden;
            this.genreText.Visibility = Visibility.Hidden;
            this.directorLabel.Visibility = Visibility.Hidden;
            this.directorText.Visibility = Visibility.Hidden;
            this.writerLabel.Visibility = Visibility.Hidden;
            this.writerText.Visibility = Visibility.Hidden;
            this.actorsLabel.Visibility = Visibility.Hidden;
            this.actorsText.Visibility = Visibility.Hidden;
            this.plotLabel.Visibility = Visibility.Hidden;
            this.plotText.Visibility = Visibility.Hidden;
            this.langLabel.Visibility = Visibility.Hidden;
            this.languageText.Visibility = Visibility.Hidden;
            this.countryLabel.Visibility = Visibility.Hidden;
            this.countryText.Visibility = Visibility.Hidden;
            this.awardsLabel.Visibility = Visibility.Hidden;
            this.awardsText.Visibility = Visibility.Hidden;
            this.typeLabel.Visibility = Visibility.Hidden;
            this.typeText.Visibility = Visibility.Hidden;
            this.dvdLabel.Visibility = Visibility.Hidden;
            this.dvdText.Visibility = Visibility.Hidden;
            this.richTextUpdater.Visibility = Visibility.Hidden;
            this.commentTextBlock.Visibility = Visibility.Hidden;
            this.commentUpdateButton.Visibility = Visibility.Hidden;
            this.commentLabel.Visibility = Visibility.Hidden;
            this.playButton.Visibility = Visibility.Hidden;
            this.pathUpdateButton.Visibility = Visibility.Hidden;
            this.deleteFromDataBaseButton.Visibility = Visibility.Hidden;
            this.resultlistTitle.Visibility = Visibility.Hidden;
            this.clearResult.Visibility = Visibility.Hidden;
                  
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

        private void resultListTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            titleText.Visibility = Visibility.Visible;
            yearText.Visibility = Visibility.Visible;
            ratedText.Visibility = Visibility.Visible;
            releasedText.Visibility = Visibility.Visible;
            runtimeText.Visibility = Visibility.Visible;
            genreText.Visibility = Visibility.Visible;
            directorText.Visibility = Visibility.Visible;
            writerText.Visibility = Visibility.Visible;
            actorsText.Visibility = Visibility.Visible;
            plotText.Visibility = Visibility.Visible;
            languageText.Visibility = Visibility.Visible;
            countryText.Visibility = Visibility.Visible;
            awardsText.Visibility = Visibility.Visible;
            typeText.Visibility = Visibility.Visible;
            dvdText.Visibility = Visibility.Visible;



            if (this.resultlistTitle.SelectedIndex != -1)
            {
                    setData(tempRecords[resultlistTitle.SelectedIndex].Type, tempRecords[resultlistTitle.SelectedIndex].ImdbId);
                
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
            resultlistTitle.Items.Remove(resultlistTitle.SelectedIndex);
            tempRecords.RemoveAt(resultlistTitle.SelectedIndex);


            imdbidLabel.Visibility = Visibility.Collapsed;
            imdbidText.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            titleText.Visibility = Visibility.Collapsed;
            yearLabel.Visibility = Visibility.Collapsed;
            yearText.Visibility = Visibility.Collapsed;
            ratedLabel.Visibility = Visibility.Collapsed;
            ratedText.Visibility = Visibility.Collapsed;
            releasedLabel.Visibility = Visibility.Collapsed;
            releasedText.Visibility = Visibility.Collapsed;
            runtimeLabel.Visibility = Visibility.Collapsed;
            runtimeText.Visibility = Visibility.Collapsed;
            genreLabel.Visibility = Visibility.Collapsed;
            genreText.Visibility = Visibility.Collapsed;
            directorLabel.Visibility = Visibility.Collapsed;
            directorText.Visibility = Visibility.Collapsed;
            writerLabel.Visibility = Visibility.Collapsed;
            writerText.Visibility = Visibility.Collapsed;
            actorsLabel.Visibility = Visibility.Collapsed;
            actorsText.Visibility = Visibility.Collapsed;
            plotLabel.Visibility = Visibility.Collapsed;
            plotText.Visibility = Visibility.Collapsed;
            langLabel.Visibility = Visibility.Collapsed;
            languageText.Visibility = Visibility.Collapsed;
            countryLabel.Visibility = Visibility.Collapsed;
            countryText.Visibility = Visibility.Collapsed;
            awardsLabel.Visibility = Visibility.Collapsed;
            awardsText.Visibility = Visibility.Collapsed;
            typeLabel.Visibility = Visibility.Collapsed;
            typeText.Visibility = Visibility.Collapsed;
            dvdLabel.Visibility = Visibility.Collapsed;
            dvdText.Visibility = Visibility.Collapsed;
            richTextUpdater.Visibility = Visibility.Collapsed;
            commentTextBlock.Visibility = Visibility.Collapsed;
            commentUpdateButton.Visibility = Visibility.Collapsed;
            commentLabel.Visibility = Visibility.Collapsed;
            playButton.Visibility = Visibility.Collapsed;
            pathUpdateButton.Visibility = Visibility.Collapsed;
            deleteFromDataBaseButton.Visibility = Visibility.Collapsed;
        }

        public void setData(string type, string imdbID)
        {
            if (type.Equals("movie"))
            {
                for (int i = 0; i < tempRecords.Count; i++)
                {
                    if (tempRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = tempRecords[i].Title;
                        this.year = tempRecords[i].Year;
                        this.rated = tempRecords[i].Rated;
                        this.released = tempRecords[i].Released;
                        this.runtime = tempRecords[i].Runtime;
                        this.genre = tempRecords[i].Genre;
                        this.director = tempRecords[i].Director;
                        this.writer = tempRecords[i].Writer;
                        this.actors = tempRecords[i].Actors;
                        this.plot = tempRecords[i].Plot;
                        this.lang = tempRecords[i].Lang;
                        this.country = tempRecords[i].Country;
                        this.awardsS = tempRecords[i].Awards;
                        this.poster = tempRecords[i].Poster;
                        this.ImdbId = tempRecords[i].ImdbId;
                        this.Type = tempRecords[i].Type;
                        this.dvdRel = tempRecords[i].DvdRel;
                        this.website = tempRecords[i].Website;
                        this.Local = tempRecords[i].Local;
                        this.comment = tempRecords[i].Comment;
                        this.Rowid = tempRecords[i].RowID;
                    }
                }
            }
            else if (type.Equals("series"))
            {
                for (int i = 0; i < tempRecords.Count; i++)
                {
                    if (tempRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = tempRecords[i].Title;
                        this.year = tempRecords[i].Year;
                        this.rated = tempRecords[i].Rated;
                        this.released = tempRecords[i].Released;
                        this.runtime = tempRecords[i].Runtime;
                        this.genre = tempRecords[i].Genre;
                        this.director = tempRecords[i].Director;
                        this.writer = tempRecords[i].Writer;
                        this.actors = tempRecords[i].Actors;
                        this.plot = tempRecords[i].Plot;
                        this.lang = tempRecords[i].Lang;
                        this.country = tempRecords[i].Country;
                        this.awardsS = tempRecords[i].Awards;
                        this.poster = tempRecords[i].Poster;
                        this.ImdbId = tempRecords[i].ImdbId;
                        this.Type = tempRecords[i].Type;
                        this.dvdRel = tempRecords[i].DvdRel;
                        this.website = tempRecords[i].Website;
                        this.Local = tempRecords[i].Local;
                        this.comment = tempRecords[i].Comment;
                        this.Rowid = tempRecords[i].RowID;
                    }
                }
            }
            else
            {
                for (int i = 0; i < tempRecords.Count; i++)
                {
                    if (tempRecords[i].ImdbId == imdbID)
                    {
                        this.Title1 = tempRecords[i].Title;
                        this.year = tempRecords[i].Year;
                        this.rated = tempRecords[i].Rated;
                        this.released = tempRecords[i].Released;
                        this.runtime = tempRecords[i].Runtime;
                        this.genre = tempRecords[i].Genre;
                        this.director = tempRecords[i].Director;
                        this.writer = tempRecords[i].Writer;
                        this.actors = tempRecords[i].Actors;
                        this.plot = tempRecords[i].Plot;
                        this.lang = tempRecords[i].Lang;
                        this.country = tempRecords[i].Country;
                        this.awardsS = tempRecords[i].Awards;
                        this.poster = tempRecords[i].Poster;
                        this.ImdbId = tempRecords[i].ImdbId;
                        this.Type = tempRecords[i].Type;
                        this.dvdRel = tempRecords[i].DvdRel;
                        this.website = tempRecords[i].Website;
                        this.Local = tempRecords[i].Local;
                        this.comment = tempRecords[i].Comment;
                        this.Rowid = tempRecords[i].RowID;
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

        private void FilterTypeList_DropDownOpened(object sender, EventArgs e)
        {
            this.optionList.Items.Clear();
        }
    }



}

