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

        public Dictionary<EnsembleAudio, LinkedList<Piste>> Mediatheque;

        public void AjouterEnsemblePiste(EnsembleAudio E, LinkedList<Piste>LP)
        {
            Mediatheque.Add(E,LP);
        }

        override

        public string ToString()
        {
            return $"Compteur : {CompteurAlbum}\n Médiathèque : {Mediatheque}";
        }

    }
}
