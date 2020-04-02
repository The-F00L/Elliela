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
using System.Windows.Shapes;

namespace Elliela2._0
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {

            InitializeComponent();

            //hide images
            image1.Visibility = Visibility.Collapsed;
            image2.Visibility = Visibility.Collapsed;
            image3.Visibility = Visibility.Collapsed;
            image4.Visibility = Visibility.Collapsed;
            image5.Visibility = Visibility.Collapsed;
            image6.Visibility = Visibility.Collapsed;
            image7.Visibility = Visibility.Collapsed;
            image8.Visibility = Visibility.Collapsed;
            image9.Visibility = Visibility.Collapsed;
            image10.Visibility = Visibility.Collapsed;

            //hide buttons
            button1.Visibility = Visibility.Collapsed;
            button2.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
            button4.Visibility = Visibility.Collapsed;
            button5.Visibility = Visibility.Collapsed;
            button6.Visibility = Visibility.Collapsed;
            button7.Visibility = Visibility.Collapsed;
            button8.Visibility = Visibility.Collapsed;
            button9.Visibility = Visibility.Collapsed;
            button10.Visibility = Visibility.Collapsed;

            //stretch def
            image1.Stretch = Stretch.Uniform;
            image2.Stretch = Stretch.Uniform;
            image3.Stretch = Stretch.Uniform;
            image4.Stretch = Stretch.Uniform;
            image5.Stretch = Stretch.Uniform;
            image6.Stretch = Stretch.Uniform;
            image7.Stretch = Stretch.Uniform;
            image8.Stretch = Stretch.Uniform;
            image9.Stretch = Stretch.Uniform;
            image10.Stretch = Stretch.Uniform;
        }

        private List<string> imdbID;
        private List<string> posters;
        private List<string> title;
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            
            omdbapi omdbAPI = new omdbapi(nameText.Text, typeCombo.Text);
            imdbID = omdbAPI.getID();
            posters = omdbAPI.getPoster();
            title = omdbAPI.getTitle();
            
            
            
            //clear images
            image1.Source = null;
            image2.Source = null;
            image3.Source = null;
            image4.Source = null;
            image5.Source = null;
            image6.Source = null;
            image7.Source = null;
            image8.Source = null;
            image9.Source = null;
            image10.Source = null;

            //clear title laber
            film1.Content = null;
            film2.Content = null;
            film3.Content = null;
            film4.Content = null;
            film5.Content = null;
            film6.Content = null;
            film7.Content = null;
            film8.Content = null;
            film9.Content = null;
            film10.Content = null;

            //clear buttons
            button1.Visibility = Visibility.Collapsed;
            button2.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
            button4.Visibility = Visibility.Collapsed;
            button5.Visibility = Visibility.Collapsed;
            button6.Visibility = Visibility.Collapsed;
            button7.Visibility = Visibility.Collapsed;
            button8.Visibility = Visibility.Collapsed;
            button9.Visibility = Visibility.Collapsed;
            button10.Visibility = Visibility.Collapsed;
           
            setPosters(posters.Count);

        }
        private void setPosters(int db) {
            switch (db)
            {
                case 1:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    break;
                case 2:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    break;
                case 3:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    break;
                case 4:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    break;
                case 5:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    break;
                    
                case 6:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    if (!posters[5].Trim().ToLower().Equals("n/a"))
                    {
                        button6.Visibility = Visibility.Visible;
                        image6.Visibility = Visibility.Visible;
                        image6.Source = new BitmapImage(new Uri(posters[5]));

                    }
                    else
                    {
                        image6.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image6.Visibility = Visibility.Visible;
                        button6.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    film6.Content = title[5];
                    break;
                case 7:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    if (!posters[5].Trim().ToLower().Equals("n/a"))
                    {
                        button6.Visibility = Visibility.Visible;
                        image6.Visibility = Visibility.Visible;
                        image6.Source = new BitmapImage(new Uri(posters[5]));

                    }
                    else
                    {
                        image6.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image6.Visibility = Visibility.Visible;
                        button6.Visibility = Visibility.Visible;
                    }
                    if (!posters[6].Trim().ToLower().Equals("n/a"))
                    {
                        button7.Visibility = Visibility.Visible;
                        image7.Visibility = Visibility.Visible;
                        image7.Source = new BitmapImage(new Uri(posters[6]));

                    }
                    else
                    {
                        image7.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image7.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    film6.Content = title[5];
                    film7.Content = title[6];
                    break;
                case 8:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    if (!posters[5].Trim().ToLower().Equals("n/a"))
                    {
                        button6.Visibility = Visibility.Visible;
                        image6.Visibility = Visibility.Visible;
                        image6.Source = new BitmapImage(new Uri(posters[5]));

                    }
                    else
                    {
                        image6.Visibility = Visibility.Visible;
                        button6.Visibility = Visibility.Visible;
                    }
                    if (!posters[6].Trim().ToLower().Equals("n/a"))
                    {
                        button7.Visibility = Visibility.Visible;
                        image7.Visibility = Visibility.Visible;
                        image7.Source = new BitmapImage(new Uri(posters[6]));

                    }
                    else
                    {
                        image7.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[7].Trim().ToLower().Equals("n/a"))
                    {
                        button8.Visibility = Visibility.Visible;
                        image8.Visibility = Visibility.Visible;
                        image8.Source = new BitmapImage(new Uri(posters[7]));
                       
                    }
                    else
                    {
                        image8.Visibility = Visibility.Visible;
                        button8.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    film6.Content = title[5];
                    film7.Content = title[6];
                    film8.Content = title[7];
                    break;
                case 9:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    if (!posters[5].Trim().ToLower().Equals("n/a"))
                    {
                        button6.Visibility = Visibility.Visible;
                        image6.Visibility = Visibility.Visible;
                        image6.Source = new BitmapImage(new Uri(posters[5]));

                    }
                    else
                    {
                        image6.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image6.Visibility = Visibility.Visible;
                        button6.Visibility = Visibility.Visible;
                    }
                    if (!posters[6].Trim().ToLower().Equals("n/a"))
                    {
                        button7.Visibility = Visibility.Visible;
                        image7.Visibility = Visibility.Visible;
                        image7.Source = new BitmapImage(new Uri(posters[6]));

                    }
                    else
                    {
                        image7.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image7.Visibility = Visibility.Visible;
                        button7.Visibility = Visibility.Visible;
                    }
                    if (!posters[7].Trim().ToLower().Equals("n/a"))
                    {
                        button8.Visibility = Visibility.Visible;
                        image8.Visibility = Visibility.Visible;
                        image8.Source = new BitmapImage(new Uri(posters[7]));

                    }
                    else
                    {
                        image8.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image8.Visibility = Visibility.Visible;
                        button8.Visibility = Visibility.Visible;
                    }
                    if (!posters[8].Trim().ToLower().Equals("n/a"))
                    {
                        button9.Visibility = Visibility.Visible;
                        image9.Visibility = Visibility.Visible;
                        image9.Source = new BitmapImage(new Uri(posters[8]));
                        
                    }
                    else
                    {
                        image9.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image9.Visibility = Visibility.Visible;
                        button9.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    film6.Content = title[5];
                    film7.Content = title[6];
                    film8.Content = title[7];
                    film9.Content = title[8];
                    break;
                case 10:
                    if (!posters[0].Trim().ToLower().Equals("n/a"))
                    {
                        button1.Visibility = Visibility.Visible;
                        image1.Visibility = Visibility.Visible;
                        image1.Source = new BitmapImage(new Uri(posters[0]));

                    }
                    else
                    {
                        image1.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image1.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                    }
                    if (!posters[1].Trim().ToLower().Equals("n/a"))
                    {
                        button2.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        image2.Source = new BitmapImage(new Uri(posters[1]));

                    }
                    else
                    {
                        image2.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image2.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                    }
                    if (!posters[2].Trim().ToLower().Equals("n/a"))
                    {
                        button3.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Visible;
                        image3.Source = new BitmapImage(new Uri(posters[2]));

                    }
                    else
                    {
                        image3.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image3.Visibility = Visibility.Visible;
                        button3.Visibility = Visibility.Visible;
                    }
                    if (!posters[3].Trim().ToLower().Equals("n/a"))
                    {
                        button4.Visibility = Visibility.Visible;
                        image4.Visibility = Visibility.Visible;
                        image4.Source = new BitmapImage(new Uri(posters[3]));

                    }
                    else
                    {
                        image4.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image4.Visibility = Visibility.Visible;
                        button4.Visibility = Visibility.Visible;
                    }
                    if (!posters[4].Trim().ToLower().Equals("n/a"))
                    {
                        button5.Visibility = Visibility.Visible;
                        image5.Visibility = Visibility.Visible;
                        image5.Source = new BitmapImage(new Uri(posters[4]));

                    }
                    else
                    {
                        image5.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image5.Visibility = Visibility.Visible;
                        button5.Visibility = Visibility.Visible;
                    }
                    if (!posters[5].Trim().ToLower().Equals("n/a"))
                    {
                        button6.Visibility = Visibility.Visible;
                        image6.Visibility = Visibility.Visible;
                        image6.Source = new BitmapImage(new Uri(posters[5]));

                    }
                    else
                    {
                        image6.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image6.Visibility = Visibility.Visible;
                        button6.Visibility = Visibility.Visible;
                    }
                    if (!posters[6].Trim().ToLower().Equals("n/a"))
                    {
                        button7.Visibility = Visibility.Visible;
                        image7.Visibility = Visibility.Visible;
                        image7.Source = new BitmapImage(new Uri(posters[6]));

                    }
                    else
                    {
                        image7.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image7.Visibility = Visibility.Visible;
                        button7.Visibility = Visibility.Visible;
                    }
                    if (!posters[7].Trim().ToLower().Equals("n/a"))
                    {
                        button8.Visibility = Visibility.Visible;
                        image8.Visibility = Visibility.Visible;
                        image8.Source = new BitmapImage(new Uri(posters[7]));

                    }
                    else
                    {
                        image8.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image8.Visibility = Visibility.Visible;
                        button8.Visibility = Visibility.Visible;
                    }
                    if (!posters[8].Trim().ToLower().Equals("n/a"))
                    {
                        button9.Visibility = Visibility.Visible;
                        image9.Visibility = Visibility.Visible;
                        image9.Source = new BitmapImage(new Uri(posters[8]));

                    }
                    else
                    {
                        image9.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image9.Visibility = Visibility.Visible;
                        button9.Visibility = Visibility.Visible;
                    }
                    if (!posters[9].Trim().ToLower().Equals("n/a"))
                    {
                        button10.Visibility = Visibility.Visible;
                        image10.Visibility = Visibility.Visible;
                        image10.Source = new BitmapImage(new Uri(posters[9]));
                        
                    }
                    else
                    {
                        image10.Source = new BitmapImage(new Uri("/rsc/notavaible.jpg", UriKind.Relative));
                        image10.Visibility = Visibility.Visible;
                        button10.Visibility = Visibility.Visible;
                    }
                    film1.Content = title[0];
                    film2.Content = title[1];
                    film3.Content = title[2];
                    film4.Content = title[3];
                    film5.Content = title[4];
                    film6.Content = title[5];
                    film7.Content = title[6];
                    film8.Content = title[7];
                    film9.Content = title[8];
                    film10.Content = title[9];
                    break;
                default:
                    break;
            }
        }
        private detailsINFO detailsInfo = new detailsINFO();
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[0]);

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.setData(imdbID[1]);  
            detailsInfo.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[2]);

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[3]);

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[4]);

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[5]);

        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[6]);

        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[7]);

        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[8]);

        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            detailsInfo.Show();
            detailsInfo.setData(imdbID[9]);

        }
    }
}
