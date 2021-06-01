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
using System.IO;

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
        string imageName;
        string oldimage;
        public UCExpDetail()
        {
            InitializeComponent();
            DataContext = this;
         

        }

        

        private void Lire_Exp(object sender, RoutedEventArgs e)
        {
            int index = Mgr.ManagerEnsemble.ListeSelect.IndexOf(((Button)sender).Tag as Piste);

            ((MainWindow)Application.Current.MainWindow).LireDepuis(index);
        }

        private void Supprimer_Piste(object sender, RoutedEventArgs e)
        {

            if (MgrEnsemble.EnsembleSelect == Mgr.EnsembleLu)
            {
                Mgr.Playlist.Remove((Piste)ListePiste.SelectedItem);
                StopLecteur?.Invoke(sender, new RoutedEventArgs());
            }
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
            dialog.InitialDirectory = $"{Mgr.ManagerProfil.CheminBaseDonnees}";
            
            dialog.Filter = "Fichiers audio (*.mp3,*.wav)|*.mp3;*.wav";

            bool? result = dialog.ShowDialog();

            //A CHANGER

            if (result == true)
            {
                ((Piste)((Button)sender).Tag).Source = dialog.FileName;
            }

            Mgr.ManagerEnsemble.ActualiserListe();
        }

        private void PopupBox_Closed_1(object sender, RoutedEventArgs e)
        {
            Mgr.ManagerEnsemble.ActualiserListe();
        }

        private void AjouterMorceau(object sender, RoutedEventArgs e)
        {
            Morceau morceau = MgrEnsemble.AjouterMorceau("Nouveau Morceau", "", "");
            if (MgrEnsemble.EnsembleSelect == Mgr.EnsembleLu)
            {
                Mgr.Playlist.AddLast(morceau);
            }
        }

        private void AjouterPodcast(object sender, RoutedEventArgs e)
        {
            Podcast nouvPod = MgrEnsemble.AjouterPodcast("Nouveau Podcast", "", "", "", DateTime.Today);
            if (MgrEnsemble.EnsembleSelect == Mgr.EnsembleLu)
            {
                Mgr.Playlist.AddLast(nouvPod);
            }
        }

        private void Sauvegarder(object sender, RoutedEventArgs e)
        {
           
            MgrEnsemble.EnsembleSelect.ModifierEnsemble(Titre_box.Text, Etoiles.Value, Description_box.Text, MgrEnsemble.EnsembleSelect.CheminImage, (EGenre)Combo_Genre.SelectedItem);
           
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
                oldimage = MgrEnsemble.EnsembleSelect.CheminImage;
                imagesource = dialog.FileName;
                Uri uri = new Uri(imagesource);
                //imageName = uri.Segments.Last().Split("\\")[0];
                imageName = $"{ DateTime.Now.ToString().Replace("/", "").Replace(":","")}.{uri.Segments.Last().Split(".")[1]}";

                       
                //MgrEnsemble.EnsembleSelect.CheminImage = imagesource;
                File.Copy(imagesource, @$"..\img\{imageName}",true);
               
                MgrEnsemble.EnsembleSelect.ModifierImage(imageName);

             
            }
        }

        
        private void SupprimerEns(object sender, RoutedEventArgs e)
        {
            Dialog.IsOpen = true;
        }


        public event RoutedEventHandler StopLecteur;
        private void ValiderSuppr(object sender, RoutedEventArgs e)
        {
            
            Mgr.SupprimerEnsembleAudio(Mgr.ManagerEnsemble.EnsembleSelect);
            try { 

                Mgr.ManagerEnsemble.EnsembleSelect = Mgr.Mediatheque.First().Key;

            }
            catch(Exception)
            {
                if (Mgr.Mediatheque.Count == 0 && Mgr.ListeFavoris.Count == 0)
                {
                    Visibility = Visibility.Collapsed;
                    StopLecteur?.Invoke(sender, new RoutedEventArgs());
                }
            }
        }
    }
}
