using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;

namespace Flappy_Bird
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        ApplicationContext db;
        private BackgroundWorker backgroundWorker;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool isMusicPlaying = false;

        public Login()
        {
            InitializeComponent();

            //db = new ApplicationContext();
            //var existingResult = db.Results.FirstOrDefault(r => r.name == CurrentUser.currentUser.name);
            if (mediaPlayer != null && mediaPlayer.NaturalDuration.HasTimeSpan)
            {

            }
            else
            {
                // Фоновая музыка не загружена или недоступна
            }

            backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += BackgroundWorker_DoWork;
                backgroundWorker.RunWorkerAsync();
            

            

            //mediaPlayer.Open(new Uri(string.Format("{0}\\main.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            //mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
            //mediaPlayer.Play();


        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                mediaPlayer.Open(new Uri(string.Format("{0}\\main.mp3", AppDomain.CurrentDomain.BaseDirectory)));
                mediaPlayer.MediaEnded += (s, args) => mediaPlayer.Position = TimeSpan.Zero;
            });

            while (true)
            {
                if (!isMusicPlaying)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        mediaPlayer.Play();
                        isMusicPlaying = true;
                    });
                }

                Thread.Sleep(1000);
            }
        }

 
        private void Media_Ended(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.music)
            {
                mediaPlayer.Position = TimeSpan.Zero;
                mediaPlayer.Play();
            }
        }



        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\die.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            System.Windows.Application.Current.Shutdown();
        }

  

        private async void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

   

            string name = password.Text;

            if(name == "" || name == "name")
            {

            }
            else
            {
                loadingVideo.Source = new Uri(string.Format("{0}\\loading.gif", AppDomain.CurrentDomain.BaseDirectory));
                loadingVideo.Visibility = Visibility.Visible;
                loadingVideo.Play();

            
                MediaPlayer mplayer = new MediaPlayer();
                mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
                mplayer.Play();

                db = new ApplicationContext();

                List<Result> results = db.Results.ToList();
                Boolean isUser = false;
                string str = "";
                foreach (Result result in results)
                {
                    if (name == result.name)
                    {
                        CurrentUser.setCurrentUser(result);
                        isUser = true;
                        break;
                    }
                }
                if (!isUser)
                {
                    Result result = new Result(name, 0, 0, 0, 0);
                    db.Results.Add(result);
                    db.SaveChanges();
                    CurrentUser.setCurrentUser(result);
                }

                await Task.Delay(1000);

                loadingVideo.Stop();
                loadingVideo.Visibility = Visibility.Hidden;

                Main m = new Main();
                m.Show();
                this.Close();
            }

           
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Usermanual u = new Usermanual();
            u.Show();
            this.Close();
        }
    }
}
