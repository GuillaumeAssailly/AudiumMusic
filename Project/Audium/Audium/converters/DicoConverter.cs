using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Donnees;
using Gestionnaires;

namespace Audium.converters
{
    class DicoConverter : IValueConverter
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Motcle= ((MainWindow)Application.Current.MainWindow).Motcle;
            //ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>> discotheque = value as ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>>;

            Dictionary<EnsembleAudio, LinkedList<Piste>> discothequeResultat;

            ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>> discotheque = Mgr.Mediatheque;

            // Récuperer GenreSelect, l'utiliser dans la recherche et ajouter le dico obtenu a un dico général, faire pareil avec les mots clés
            if (Genre.GetGenre(Mgr.GenreSelect) != EGenre.AUCUN)
            {
                discothequeResultat = URecherche.RechercherParGenre(Genre.GetGenre(Mgr.GenreSelect), discotheque);

                if (!string.IsNullOrWhiteSpace(Motcle))
                {
                    discothequeResultat = URecherche.RechercherParMotCle(Motcle, new ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>>(discothequeResultat));
                }
            }
            else if (!string.IsNullOrWhiteSpace(Motcle))
            {
                discothequeResultat = URecherche.RechercherParMotCle(Motcle, discotheque);
            }
            else
            {
                return Mgr.Mediatheque.Keys;
            }
            return discothequeResultat.Keys;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
