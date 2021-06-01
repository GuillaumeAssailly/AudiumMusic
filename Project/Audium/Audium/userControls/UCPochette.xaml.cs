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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Audium.userControls
{
    /// <summary>
    /// Logique d'interaction pour UCPochette.xaml
    /// </summary>
    public partial class UCPochette : UserControl
    {
        public UCPochette()
        {
            InitializeComponent();
        }


        public string ImageName
        {
            get { return (string)GetValue(ImageNameProperty); }
            set { SetValue(ImageNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageNameProperty =
            DependencyProperty.Register("ImageName", typeof(string), typeof(UCPochette), new PropertyMetadata(@"icondefault\default.png"));

        public event RoutedEventHandler BoutonLire;
        public event RoutedEventHandler CliquePochette;
        public event RoutedEventHandler CliqueFavori;

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            BoutonLire?.Invoke(sender, new RoutedEventArgs());
        }

        private void Canvas_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            CliquePochette?.Invoke(sender, e);
        }

        private void FavButton_Click(object sender, RoutedEventArgs e)
        {
            CliqueFavori?.Invoke(sender, e);
        }
    }
}
