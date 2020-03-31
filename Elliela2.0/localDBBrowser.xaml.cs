using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;

namespace Elliela2._0
{
    /// <summary>
    /// Interaction logic for localDBBrowser.xaml
    /// </summary>
    public partial class localDBBrowser : Window
    {

        public localDBBrowser()
        {
            InitializeComponent();
            this.main.Content = new overView();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private static Uri path;
        private static bool play;

        public static Uri Path { get => path; set => path = value; }
        public static bool Play { get => play; set => play = value; }



        private void LocalDBSearch_Click(object sender, RoutedEventArgs e)
        {
            this.main.Content = new searchLocal();
        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            this.main.Content = new overView();
        }
     
        public bool getPlay()
        {
            return play;
        }

        public void setPlay()
        {
            Play = false;
        }

        public Uri getPath()
        {
            return path;
        }

       



    }
}
