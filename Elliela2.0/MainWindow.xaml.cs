using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Elliela2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        private string title;
        private Uri path;
        private static localDBBrowser localDB = new localDBBrowser();

        public MainWindow()
        {
            InitializeComponent();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliderProgressStatus.Minimum = 0;
                sliderProgressStatus.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliderProgressStatus.Value = mediaPlayer.Position.TotalSeconds;
            }
            if (localDB.getPlay())
            {
                mediaPlayer.Source = localDB.getPath();
                mediaPlayer.Play();
                mediaPlayer.Stretch = Stretch.Uniform;
                localDB.Visibility = Visibility.Hidden;
                localDB.setPlay();
            }
            
        }



        private void sliderProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliderProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(sliderProgressStatus.Value);
        }

        private void sliderProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            progressStatusTime.Text = TimeSpan.FromSeconds(sliderProgressStatus.Value).ToString(@"hh\:mm\:ss");
        }
        private void gridMouseWheel(object sender, MouseWheelEventArgs e)
        {
            mediaPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp4;*.mkv;*.flc)|*.mp4;*.mkv;*.flc|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                mediaPlayer.Source = new Uri(openFileDialog.FileName);
            mediaPlayer.Play();
            mediaPlayer.Stretch = Stretch.Uniform;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
            mediaPlayerIsPlaying = true;
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
        
        private void SearchDBButton_Click(object sender, RoutedEventArgs e)
        {
            Search searchWpf = new Search();
            searchWpf.Show();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LocalDBButton_Click(object sender, RoutedEventArgs e)
        {
            localDB.Show();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.C)
            {
                mediaPlayer.Play();
            }
            if (e.Key==Key.V)
            {
                mediaPlayer.Pause();
            }
            if (e.Key==Key.B)
            {
                mediaPlayer.Volume++;
            }
            if (e.Key==Key.N)
            {
                mediaPlayer.Volume--;
            }
            if (e.Key==Key.M)
            {
                mediaPlayer.Stop();
            }

        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }

}
   

