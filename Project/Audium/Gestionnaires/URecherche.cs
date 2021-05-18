using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;



namespace Gestionnaires
{
    public abstract class URecherche 
    {

        public static Dictionary<EnsembleAudio, LinkedList<Piste>> RechercherParGenre(EGenre GenreRecherche, ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>> Discotheque)
        {
            return Discotheque.Where(ensemble => ensemble.Key.Genre.Equals(GenreRecherche)).ToDictionary(x => x.Key, x => x.Value);
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

        public static Dictionary<EnsembleAudio,LinkedList<Piste>> RechercherParMotCle(string rech, ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>> Discotheque)
        {
            Dictionary<EnsembleAudio, LinkedList<Piste>> Recherche = new();
            Recherche = Discotheque.Where(ensemble => (ensemble.Key.Titre.ToLower().Contains(rech.ToLower()))).ToDictionary(x=> x.Key, x=> x.Value);

            foreach (LinkedList<Piste> liste in Discotheque.Values)
            {
                foreach (Piste piste in liste)
                {
                    
                    if(Recherche.ContainsKey(Discotheque.FirstOrDefault(x => x.Value == liste).Key))
                    {
                        break;
                    }
                    if (piste.Titre.ToLower().Contains(rech.ToLower()))
                    {
                        Recherche.Add(Discotheque.FirstOrDefault(x => x.Value == liste).Key, liste);
                    }
                    else if (piste is Morceau && ((Morceau)piste).Artiste.ToLower().Contains(rech.ToLower()))
                    {
                        Recherche.Add(Discotheque.FirstOrDefault(x => x.Value == liste).Key, liste);
                    }
                    else if (piste is Podcast && ((Podcast)piste).Auteur.ToLower().Contains(rech.ToLower()))
                    {
                        Recherche.Add(Discotheque.FirstOrDefault(x => x.Value == liste).Key, liste);
                    }                
                }
            }
            return Recherche;
        }


    }
}
