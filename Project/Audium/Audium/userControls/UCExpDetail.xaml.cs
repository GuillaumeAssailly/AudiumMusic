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
using Gestionnaires;
using Donnees;
using System.Diagnostics;

namespace Audium.userControls
{
    /// <summary>
    /// Logique d'interaction pour UCExpDetail.xaml
    /// </summary>
    public partial class UCExpDetail : UserControl


    {
        public Manager Mgr => (App.Current as App).LeManager;

        public ManagerEnsembleSelect MgrEnsemble => (App.Current as App).LeManager.ManagerEnsemble;

        string imagesource;

        public UCExpDetail()
        {
            InitializeComponent();
            DataContext = Mgr.ManagerEnsemble;
        }

        private void Lire_Exp(object sender, RoutedEventArgs e)
        {
            int index = Mgr.ManagerEnsemble.ListeSelect.IndexOf(((Button)sender).Tag as Piste);

            ((MainWindow)Application.Current.MainWindow).LireDepuis(index + 1);
        }

        private void Supprimer_Piste(object sender, RoutedEventArgs e)
        {
            
            try
            {
                MgrEnsemble.SupprimerPiste((Piste)ListePiste.SelectedItem);
            }
            catch (ArgumentException erreur)
            {
                Debug.WriteLine(erreur.Message);
            }
        }

       

        private void PopupBox_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            Mgr.ManagerEnsemble.ActualiserListe();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            
            dialog.Filter = "Fichiers audio (*.mp3,*.wav)|*.mp3;*.wav";

            bool? result = dialog.ShowDialog();

            //A CHANGER

            if (result == true)
            {
                ((Morceau)((Button)sender).Tag).Chemin = dialog.FileName;
            }

            Mgr.ManagerEnsemble.ActualiserListe();
        }

        private void PopupBox_Closed_1(object sender, RoutedEventArgs e)
        {
            Mgr.ManagerEnsemble.ActualiserListe();
        }

        private void AjouterMorceau(object sender, RoutedEventArgs e)
        {
            MgrEnsemble.AjouterMorceau("Nouveau Morceau", "", "");
        }

        private void AjouterPodcast(object sender, RoutedEventArgs e)
        {
            MgrEnsemble.AjouterPodcast("Nouveau Podcast", "", "", "", DateTime.Today);
        }

        private void Sauvegarder(object sender, RoutedEventArgs e)
        {
           
            MgrEnsemble.EnsembleSelect.ModifierEnsemble(Titre_box.Text, Etoiles.Value, Description_box.Text, MgrEnsemble.EnsembleSelect.CheminImage, EGenre.BANDEORIGINALE);
            Debug.WriteLine(Etoiles.Value);
        }

        public event RoutedEventHandler CliqueFavori;
        private void FavButton_Click(object sender, RoutedEventArgs e)
        {
            CliqueFavori?.Invoke(sender, e);
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg| .gif |.png";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                imagesource = dialog.FileName;
                //ImagePochette.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
                MgrEnsemble.EnsembleSelect.CheminImage = imagesource;
            }
        }
    }
}
