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
    /// Логика взаимодействия для Usermanual.xaml
    /// </summary>
    public partial class Usermanual : Window
    {
        public Usermanual()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Usermanual2 u = new Usermanual2();
            u.Show();
            this.Close();
        }
    }
}
