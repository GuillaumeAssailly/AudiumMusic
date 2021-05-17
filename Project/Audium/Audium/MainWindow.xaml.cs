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
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using Donnees;
using Gestionnaires;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using System.IO;

namespace Audium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public Manager Mgr => (App.Current as App).LeManager;
        public ManagerProfil MgrProfil => (App.Current as App).LeManagerProfil;

        

        //public  MediaPlayer Lecteur;
        bool isPlaying = false;
        TimeSpan position;
        DispatcherTimer timer = new DispatcherTimer();

       
        
        

     


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //Lecteur = new MediaPlayer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(tick);
            timer.Start();
            Lecteur.MediaEnded += Media_Next;
            Lecteur.MediaOpened += Media_Opened;
            Lecteur.MediaFailed += Media_Stopped;

        }


        void tick(object sender, EventArgs e) 
        {
            ProgressBar.Value = Lecteur.Position.TotalSeconds;
            TimerDisplay.Text = Lecteur.Position.ToString(@"mm\:ss");
        }

        private void OpenFolderMusic(Object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"c:\Users");

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

            //AJOUTER DES TRUCS
            MainExp.IsExpanded = true;
        }

        private void OpenExp(Object sender, RoutedEventArgs e)
        {
            MainExp.IsExpanded = true;
        }

        private void TagButton(object sender, MouseButtonEventArgs e)
        {
            MainExp.IsExpanded = false;
            URecherche.RechercherParGenre(EGenre.JAZZ, Mgr);
        }


        private void LireTout(object sender, RoutedEventArgs e)
        {
            Mgr.MediaIndex = 1;
            
           
            Mgr.EnsembleLu = ((Button)sender).Tag as EnsembleAudio;


            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), $"..\\..\\..\\music\\{Mgr.EnsembleLu.Titre}\\Track 1.mp3"));

            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex-1).Titre;

            Lecteur.Play();
            PlayPauseIcon.Kind = PackIconKind.Pause;
            isPlaying = true;
           
        }
        public void LireDepuis(int index)
        {
            Mgr.MediaIndex = index;


            Mgr.EnsembleLu = Mgr.EnsembleSelect;


            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), $"..\\..\\..\\music\\{Mgr.EnsembleLu.Titre}\\Track {Mgr.MediaIndex}.mp3"));

            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex - 1).Titre;

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
            if(Mgr.MediaIndex < Mgr.Playlist.Count)
            {
                Mgr.MediaIndex++;
            }
            else if(Mgr.MediaIndex==Mgr.Playlist.Count)
            {
                Lecteur.Stop();
                isPlaying = false;
                PlayPauseIcon.Kind = PackIconKind.Play;
                return;
            }
            Lecteur.Stop();
            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), $"..\\..\\..\\music\\{Mgr.EnsembleLu.Titre}\\Track {Mgr.MediaIndex}.mp3"));
            Lecteur.Play();
            
           
            isPlaying = true;
            PlayPauseIcon.Kind = PackIconKind.Pause;
            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex - 1).Titre;

        }
      
        private void Media_Previous(object sender, EventArgs e)
        {
            if (Mgr.MediaIndex > 1)
            {
                Mgr.MediaIndex--;
            }
            
            Lecteur.Stop();
            Lecteur.Source = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), $"..\\..\\..\\music\\{Mgr.EnsembleLu.Titre}\\Track {Mgr.MediaIndex}.mp3")); 
            Lecteur.Play();
            isPlaying = true;
            PlayPauseIcon.Kind = PackIconKind.Pause;
            TitleDisplay.Text = Mgr.Playlist.ElementAtOrDefault(Mgr.MediaIndex - 1).Titre;
        }
       
        private void ProgressBarChanged(object sender, MouseButtonEventArgs e)
        {
            
            int pos = Convert.ToInt32(ProgressBar.Value);
            Lecteur.Position = new TimeSpan(0, 0, 0, pos, 0);
           
        }

        private void ProgressBarValueSlided(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ProgressBar.IsMouseCaptureWithin)
            {
               
                int pos = Convert.ToInt32(ProgressBar.Value);
                Lecteur.Position = new TimeSpan(0, 0, 0, pos, 0);
                
            }
        }

        
    }
}
