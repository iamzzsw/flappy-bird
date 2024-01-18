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
    /// Логика взаимодействия для Endless.xaml
    /// </summary>
    public partial class Endless : Window
    {
        public Endless()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void playClassic_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void playCountry_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            WindowClassic wc = new WindowClassic();
            wc.Show();
            this.Close();
        }
    }
}
