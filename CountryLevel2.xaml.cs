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
using System.Windows.Threading;

namespace Flappy_Bird
{
    /// <summary>
    /// Логика взаимодействия для CountryLevel2.xaml
    /// </summary>
    public partial class CountryLevel2 : Window
    {
        ApplicationContext db;

        DispatcherTimer gameTime = new DispatcherTimer();

        double score;
        int gravity = 8;
        bool gameOver;
        Rect flappyBirdHitBox;

        public CountryLevel2()
        {
            InitializeComponent();

            gameTime.Tick += MainEventTimer;
            gameTime.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            txtScore.Content = "Score: " + score;

            flappyBirdHitBox = new Rect(Canvas.GetLeft(flappybird), Canvas.GetTop(flappybird), flappybird.Width - 15, flappybird.Height - 15);

            Canvas.SetTop(flappybird, Canvas.GetTop(flappybird) + gravity);

            if (Canvas.GetTop(flappybird) < -10 || Canvas.GetTop(flappybird) > 450)
            {
                EndGame();
            }

            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "cloud1" || (string)x.Tag == "cloud2" || (string)x.Tag == "cloud3" || (string)x.Tag == "tel1" || (string)x.Tag == "cloud4" || (string)x.Tag == "cloud5" || (string)x.Tag == "cloud6" )
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);

                    if (Canvas.GetLeft(x) < -150)
                    {
                        if (score <= 6)
                        {
                            Canvas.SetLeft(x, 2800);
                            score += .5;
                        }
                        if (score == 6)
                        {
                            gameTime.Stop();
                            gameOver = true;
                            txtWin.Content = "EXECTLY \nPress N to go to the next level";


                            db = new ApplicationContext();
                            var existingResult = db.Results.FirstOrDefault(r => r.name == CurrentUser.currentUser.name);

                            if (existingResult != null)
                            {
                                existingResult.classicRecord = CurrentUser.currentUser.classicLevel;
                                existingResult.classicLevel = CurrentUser.currentUser.classicLevel;
                                existingResult.countryRecord = CurrentUser.currentUser.countryRecord;
                                existingResult.countryLevel = 10;
                            }
                            CurrentUser.currentUser.countryLevel = 10;
                            db.SaveChanges();
                        }

                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width - 55, x.Height - 25);

                    if (flappyBirdHitBox.IntersectsWith(pipeHitBox))
                    {
                        EndGame();
                    }
                }

                if ((string)x.Tag == "bg")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);

                    if (Canvas.GetLeft(x) < -1700)
                    {
                        Canvas.SetLeft(x, 0);
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                txtWin.Content = "";
                MediaPlayer mplayer = new MediaPlayer();
                mplayer.Open(new Uri(string.Format("{0}\\click.mp3", AppDomain.CurrentDomain.BaseDirectory)));
                mplayer.Play();
                BitmapImage image = new BitmapImage(new Uri("bird2.png", UriKind.Relative));
                flappybird.Source = image;
                flappybird.RenderTransform = new RotateTransform(-20, flappybird.Width / 2, flappybird.Height / 2);
                gravity = -8;
            }

            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }
            if (e.Key == Key.M)
            {
                Main m = new Main();
                m.Show();
                this.Close();
            }
    
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri("bird1.png", UriKind.Relative));
            flappybird.Source = image;
            flappybird.RenderTransform = new RotateTransform(5, flappybird.Width / 2, flappybird.Height / 2);
            gravity = 8;
        }

        private void StartGame()
        {

            MyCanvas.Focus();

            int temp = 300;

            score = 0;

            gameOver = false;
            Canvas.SetTop(flappybird, 190);

            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "cloud1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "cloud2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "cloud3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                if ((string)x.Tag == "tel1")
                {
                    Canvas.SetLeft(x, 1400);
                }
                if ((string)x.Tag == "cloud4")
                {
                    Canvas.SetLeft(x, 1700);
                }
                if ((string)x.Tag == "cloud5")
                {
                    Canvas.SetLeft(x, 2000);
                }
                if ((string)x.Tag == "cloud6")
                {
                    Canvas.SetLeft(x, 2300);
                }

            }

            gameTime.Start();

        }

        private void EndGame()
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\die.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();

            if (score > CurrentUser.currentUser.countryRecord)
            {
                db = new ApplicationContext();
                var existingResult = db.Results.FirstOrDefault(r => r.name == CurrentUser.currentUser.name);

                if (existingResult != null)
                {
                    existingResult.countryRecord = score;
                    existingResult.classicLevel = CurrentUser.currentUser.classicLevel;
                    existingResult.classicRecord = CurrentUser.currentUser.classicRecord;
                    existingResult.countryLevel = CurrentUser.currentUser.countryLevel;
                }
                CurrentUser.currentUser.countryRecord = score;
                db.SaveChanges();

            }

            gameTime.Stop();
            gameOver = true;
            txtScore.Content = "Game Over !! Press R to try again \n Press M to exit";
        }

    }
}
