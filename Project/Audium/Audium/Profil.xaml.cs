using System;
using System.Collections.Generic;
using System.IO;
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
using Gestionnaires;


namespace Audium
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        string nombak;

        string cheminbak;


        string imageName;
        string imagesource;
        public Manager Mgr => (App.Current as App).LeManager;

        public ManagerProfil MgrProfil => (App.Current as App).LeManager.ManagerProfil;

        public Profil()
        {
            InitializeComponent();
            DataContext = MgrProfil;
            nombak = MgrProfil.Nom;
            cheminbak = MgrProfil.CheminImage;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg| .gif |.png";
            
           

            bool? result = dialog.ShowDialog();

            if(result == true)
            {
                //MgrProfil.CheminImage = dialog.FileName;
                theImage.ImageSource = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
                
                imagesource = dialog.FileName;
                Uri uri = new Uri(imagesource);


                imageName = $"{ DateTime.Now.ToString().Replace("/", "").Replace(":", "")}.{uri.Segments.Last().Split(".")[1]}";
                File.Copy(imagesource, @$"..\img\PP\{imageName}", true);
                MgrProfil.CheminImage = imageName;


            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            MgrProfil.ModifierProfil(PseudoInput.Text, MgrProfil.CheminImage);
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MgrProfil.ModifierProfil(nombak, cheminbak);
            this.Close();
        }
    }
}
