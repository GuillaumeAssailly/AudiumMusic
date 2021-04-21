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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
namespace Audium
{
    /// <summary>
    /// Logique d'interaction pour Parametres.xaml
    /// </summary>
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AmberClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Amber();
        }

        private void BlueClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Blue();
        }
        private void BlueGreyClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).BlueGrey();
        }

        private void CyanClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Cyan();
        }

        private void DeepOrangeClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).DeepOrange();
        }
        private void DeepPurpleClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).DeepPurple();
        }
        private void GreenClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Green();
        }
        private void GreyClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Grey();
        }
        private void IndigoClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Indigo();
        }
        private void LightBlueClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).LightBlue();
        }
        private void LightGreenClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).LightGreen();
        }
        private void LimeClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Lime();
        }
        private void OrangeClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Orange();
        }
        private void PinkClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Pink();
        }
        private void PurpleClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Purple();
        }
        private void RedClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Red();
        }
        private void TealClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Teal();
        }
        private void YellowClick(Object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Yellow();
        }


    }
}
