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

namespace Flappy_Bird
{
    /// <summary>
    /// Логика взаимодействия для CountryMenu.xaml
    /// </summary>
    public partial class CountryMenu : Window
    {
        public double score = CurrentUser.currentUser.countryLevel;
        public CountryMenu()
        {
            InitializeComponent();

            if (score < 5)
            {
                level2.Source = new BitmapImage(new Uri("no2.png", UriKind.RelativeOrAbsolute));

            }
            if (score < 10)
            {
                level3.Source = new BitmapImage(new Uri("no3.png", UriKind.RelativeOrAbsolute));

            }
            if (score < 15)
            {
                level4.Source = new BitmapImage(new Uri("no4.png", UriKind.RelativeOrAbsolute));

            }
            if (score < 20)
            {
                level5.Source = new BitmapImage(new Uri("no5.png", UriKind.RelativeOrAbsolute));

            }
            if (score < 30)
            {
                level6.Source = new BitmapImage(new Uri("no6.png", UriKind.RelativeOrAbsolute));

            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void Image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            CountryLevel1 cl = new CountryLevel1();
            cl.Show();
            this.Close();
        }

        private void level2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
    
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            CountryLevel1 cl = new CountryLevel1();
            cl.Show();
            this.Close();
        }

        private void level2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(score >= 5)
            {
                CountryLevel2 cl = new CountryLevel2();
                cl.Show();
                this.Close();
            }
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
        }
    }
}
