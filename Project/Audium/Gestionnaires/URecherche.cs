using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;



namespace Gestionnaires
{
    public class URecherche 
    {
        public URecherche()
        {

        }

        public static Dictionary<EnsembleAudio, LinkedList<Piste>> RechercherParGenre(EGenre.GenreMusique E)
        {
            return Manager.Mediatheque.Where(ensemble => (ensemble.Key.Genre.Equals(E))).ToDictionary(x => x.Key, x => x.Value);
        }
        /*
        public static Dictionary<EnsembleAudio, LinkedList<Piste>> RechercherParMotCle(string rech)
        {
            Dictionary<EnsembleAudio, LinkedList<Piste>> Recherche = new();
            
            foreach (EnsembleAudio e in Manager.Mediatheque.Keys.Where(ensemble => ensemble.Titre.ToLower().Contains(rech.ToLower())))
            {
                
                Recherche.Add(e, Manager.Mediatheque[e]);
            }
            foreach(LinkedList<Piste> le in Manager.Mediatheque.Values)
            {
                foreach(Piste p in le)
                {
                    if (p.Titre.ToLower().Contains(rech.ToLower()))
                    {
                        Recherche.Add(Manager.Mediatheque.FirstOrDefault(x => x.Value==le).Key, le);              
                    }
                    else if(p is Morceau && ((Morceau)p).Artiste.ToLower().Contains(rech.ToLower()))
                    {
                            Recherche.Add(Manager.Mediatheque.FirstOrDefault(x => x.Value == le).Key, le);
                    }
                }
            }

            return Recherche;

        }
        */

        public static Dictionary<EnsembleAudio,LinkedList<Piste>> RechercherParMotCle(string rech)
        {
            return Manager.Mediatheque.Where(ensemble => (ensemble.Key.Titre.ToLower().Contains(rech.ToLower()))).ToDictionary(x=> x.Key, x=> x.Value);
            
        }


    }
}
