using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;


namespace Gestionnaires
{
    public class Manager
    {
        public Manager()
        {
            CompteurAlbum = 0;
            Mediatheque = new();
        }

        public static int CompteurAlbum;

        public static Dictionary<EnsembleAudio, LinkedList<Piste>> Mediatheque;

        public void AjouterEnsemblePiste(EnsembleAudio E, LinkedList<Piste>LP)
        {
          
            Mediatheque.Add(E,LP);
            
        }

        public EnsembleAudio CreerEnsembleAudio(string titre, string description, string cheminImage, EGenre.GenreMusique genre)
        {
            //Finir cette méthode avec un if( Key.Titre n'existe pas dans discothèque) sinon Titre = Titre + "(1);
            EnsembleAudio Nouveau = new(titre, description, cheminImage, genre);
            int i = 1;
            while (Mediatheque.ContainsKey(Nouveau))
            {
                Nouveau.Titre = $"{titre} ({i})";
                i++;
            }
            return Nouveau;
        }

      
        public override string ToString()
        {
            return $"Compteur : {CompteurAlbum}\n Médiathèque : {Mediatheque}";
        }

    }
}
