﻿using System;
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
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using Donnees;
using Gestionnaires;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls.Primitives;
using Audium.userControls;

namespace Audium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public Manager Mgr => (App.Current as App).LeManager;
        public ManagerEnsembleSelect MgrEnsemble => (App.Current as App).LeManager.ManagerEnsemble;
      
    

       
        

        //public  MediaPlayer Lecteur;
        bool isPlaying = false;
        TimeSpan position;
        DispatcherTimer timer = new DispatcherTimer();

       
        //public static string Motcle;

        public string Motcle
        {
            get => motcle;
            set
            {
            motcle = value;
                OnPropertyChanged(nameof(Motcle));
                Mgr.OnPropertyChanged(nameof(Mgr.Mediatheque));
            }
        }
        private string motcle;

        public MainWindow()
        {
            InitializeComponent();
            (App.Current as App).InitTheme();
            DataContext = this;
            //Lecteur = new MediaPlayer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(tick);
            timer.Start();
            Lecteur.MediaEnded += Media_Next;
            Lecteur.MediaOpened += Media_Opened;
            Lecteur.MediaFailed += Media_Stopped;
            Recherche.KeyUp += Recherche_KeyUp;

            




    }

        private void Recherche_KeyUp(object sender, KeyEventArgs e)
        {
            Motcle = Recherche.Text;
            Mgr.ListeClé = URecherche.Recherche(Motcle, Mgr.GenreSelect, Mgr.Mediatheque);
        }

        void tick(object sender, EventArgs e) 
        {
            ProgressBar.Value = Lecteur.Position.TotalSeconds;
            TimerDisplay.Text = Lecteur.Position.ToString(@"mm\:ss");
        }

        private void OpenFolderMusic(Object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", $"{Mgr.ManagerProfil.CheminBaseDonnees}");

        }

        private void OpenParameters(Object sender, RoutedEventArgs e)
        {
            Parametres par = new Parametres();
            par.ShowDialog();
            
        }


        private void OpenProfile(Object sender, RoutedEventArgs e)
        {
            Profil pro = new Profil();
            pro.ShowDialog();
        }


        private void AddMusic(Object sender, RoutedEventArgs e)
        {
            Dialog.IsOpen = true;
        }

        private void OpenExp(Object sender, RoutedEventArgs e)
        {
            
            MainExp.IsExpanded = true;
            ListeFav.UnselectAll();
        }

    

      


        protected void LireTout(object sender, RoutedEventArgs e)
        {
            Mgr.MediaIndex = 0;
            
           
            Mgr.EnsembleLu = ((Button)sender).Tag as EnsembleAudio;
            if(Mgr.Playlist.Count==0)
            {
                Lecteur.Pause();
                Lecteur.Position = new TimeSpan(0, 0, 0, 0, 0);
                TitleDisplay.Text = Mgr.EnsembleLu.Titre;
                return;
            }
            
            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), Mgr.Playlist.ElementAt(Mgr.MediaIndex).Source));

            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex).Titre;

            Lecteur.Play();
            PlayPauseIcon.Kind = PackIconKind.Pause;
            isPlaying = true;
           
        }
        public void LireDepuis(int index)
        {
            Mgr.MediaIndex = index;


            Mgr.EnsembleLu = MgrEnsemble.EnsembleSelect;


            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), Mgr.Playlist.ElementAt(Mgr.MediaIndex).Source));

            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex).Titre;

            Lecteur.Play();
            PlayPauseIcon.Kind = PackIconKind.Pause;
            isPlaying = true;

        }

        private void Media_Opened(object sender, EventArgs e) 
        {
            position = Lecteur.NaturalDuration.TimeSpan;
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = position.TotalSeconds;
        }

        private void Media_Stopped(object sender, EventArgs e)
        {
            Lecteur.Stop();
        }


        private void PlayPause(object sender, EventArgs e)
        {
            if (isPlaying) 
            {
                Lecteur.Pause();
                isPlaying = false;
                PlayPauseIcon.Kind = PackIconKind.Play;
            }
            else
            {
                Lecteur.Play();
                isPlaying = true;
                PlayPauseIcon.Kind = PackIconKind.Pause;
            }
        }

        private void Media_Next(object sender, EventArgs e)
        {
            if(Mgr.Playlist?.Count==0 || Mgr.Playlist==null)
            {
                return;
            }


            if(Mgr.MediaIndex < Mgr.Playlist.Count-1)
            {
                Mgr.MediaIndex++;
            }
            else if(Mgr.MediaIndex==Mgr.Playlist.Count-1)
            {
                Lecteur.Stop();
                isPlaying = false;
                PlayPauseIcon.Kind = PackIconKind.Play;
                return;
            }
            Lecteur.Stop();
            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), Mgr.Playlist.ElementAt(Mgr.MediaIndex).Source));
            Lecteur.Play();
            
           
            isPlaying = true;
            PlayPauseIcon.Kind = PackIconKind.Pause;
            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex).Titre;

        }
      
        private void Media_Previous(object sender, EventArgs e)
        {
            if (Mgr.Playlist?.Count == 0 || Mgr.Playlist == null)
            {
                return;
            }
            if (Mgr.MediaIndex > 0)
            {
                Mgr.MediaIndex--;
            }
            
            Lecteur.Stop();
            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), Mgr.Playlist.ElementAt(Mgr.MediaIndex).Source)); 
            Lecteur.Play();
            isPlaying = true;
            PlayPauseIcon.Kind = PackIconKind.Pause;
            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex).Titre;
        }
       
        private void ProgressBarChanged(object sender, MouseButtonEventArgs e)
        {
            Lecteur.Pause();
            
            int pos = Convert.ToInt32(ProgressBar.Value);
            Lecteur.Position = new TimeSpan(0, 0, 0, pos, 0);
            Lecteur.Play();
        }

        private void ProgressBarValueSlided(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ProgressBar.IsMouseCaptureWithin)
            {
                int pos = Convert.ToInt32(ProgressBar.Value);
                Lecteur.Position = new TimeSpan(0, 0, 0, pos, 0);
            }
        }

        private void Clique_Fav(object sender, RoutedEventArgs e)
        {
            Mgr.ModifierListeFavoris(((ToggleButton)sender).Tag as EnsembleAudio);
        }

        private void ValiderAjout(object sender, RoutedEventArgs e)
        {
           
            Mgr.AjouterEnsemblePiste(Mgr.CreerEnsembleAudio(TitreBlock.Text), new LinkedList<Piste>());
            if (Mgr.Mediatheque.Count == 1)
            {
                
                Mgr.ManagerEnsemble.EnsembleSelect = Mgr.Mediatheque.First().Key;
                ExpanderDetail.Visibility = Visibility.Visible;
            }
        }


        private void TagListClicked(object sender, MouseButtonEventArgs e)
        {
            MainExp.IsExpanded = false;
            Mgr.ListeClé = URecherche.Recherche(Motcle, Mgr.GenreSelect, Mgr.Mediatheque);
        }

        private void ExpanderDetail_StopLecteur(object sender, RoutedEventArgs e)
        {
            TitleDisplay.Text = null;
            TimerDisplay.Text = null;
            Lecteur.Stop();
            Lecteur.Source = null;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Mgr.Sauvegarder();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            DirectoryInfo directoryInfo = Directory.CreateDirectory(@"..\img\");
            foreach(FileInfo file in directoryInfo.GetFiles()) 
            {
                if(!Mgr.Mediatheque.Keys.Any(x=>x.CheminImage == file.Name)) {
                    try { file.Delete(); }
                    catch(IOException exception) { Debug.WriteLine(exception.Message); }
                }
            }
            DirectoryInfo directoryInfoPP = Directory.CreateDirectory(@"..\img\PP\");
            foreach (FileInfo file in directoryInfoPP.GetFiles())
            {
                if (Mgr.ManagerProfil.CheminImage != file.Name)
                {
                    try { file.Delete(); }
                    catch (IOException exception) { Debug.WriteLine(exception.Message); }

                }
            }

            if (Mgr.Mediatheque.Count == 0)
            {
                ExpanderDetail.Visibility = Visibility.Collapsed;
            }



        }
    }
}