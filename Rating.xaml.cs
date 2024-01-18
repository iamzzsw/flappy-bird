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
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Window
    {
        ApplicationContext db;
        public Rating()
        {
            InitializeComponent();

            db = new ApplicationContext();

            List<Result> results = db.Results.ToList();
            double resClassic = 0;
            double resCountry = 0;
            string str = "";
            string str2 = "";
            foreach (Result result in results)
            {
                if(result.classicRecord > resClassic)
                {
                    resClassic = result.classicRecord;
                    str = result.name;
                }
                if (result.countryRecord > resCountry)
                {
                    resCountry = result.countryRecord;
                    str2 = result.name;
                }
            }              

            ratingClassic.Text = str + " : " + resClassic;
            ratingCountry.Text = str2 + " : " + resCountry;
            ratingClassicCurrent.Text = CurrentUser.currentUser.classicRecord.ToString();
            ratingCountryCurrent.Text = CurrentUser.currentUser.countryRecord.ToString();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(string.Format("{0}\\button.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mplayer.Play();
            Main m = new Main();
            m.Show();
            this.Close();
        }
    }
}
