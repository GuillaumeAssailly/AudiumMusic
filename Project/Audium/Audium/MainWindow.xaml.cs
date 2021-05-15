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

namespace Audium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Manager Mgr => (App.Current as App).LeManager;
        public ManagerProfil MgrProfil => (App.Current as App).LeManagerProfil;



       
       









        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
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

       
    }
}
