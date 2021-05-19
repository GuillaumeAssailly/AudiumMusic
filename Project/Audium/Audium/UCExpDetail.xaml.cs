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

namespace Audium
{
    /// <summary>
    /// Logique d'interaction pour UCExpDetail.xaml
    /// </summary>
    public partial class UCExpDetail : UserControl
    {
        public Manager Mgr => (App.Current as App).LeManager;

        public ManagerEnsembleSelect MgrEnsemble => (App.Current as App).LeManager.ManagerEnsemble;

        

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
    }
}
