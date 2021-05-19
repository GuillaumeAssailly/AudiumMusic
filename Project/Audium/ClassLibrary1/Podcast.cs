using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class Podcast : Piste
    {
        public Podcast(string titre, string description, string auteur, string chemin, DateTime datedesortie)
            :base($"Podcast: {titre}")
        {
            DateDeSortie = datedesortie;
            Description = description;
            Auteur = auteur;
            Chemin = chemin;
        }

        public DateTime DateDeSortie { get; private set; }
        public string Description { get; private set; }
        public string Auteur { get; private set; }
        public string Chemin { get; private set; }
        public void ModifierPodcast(string titre, string description, string chemin, string auteur, DateTime dateDeSortie)
        {
            base.Titre = $"Podcast: {titre}";
            DateDeSortie = dateDeSortie;
            Description = description;
            Auteur = auteur;
            Chemin = chemin;
        }


        public override String ToString()
        {
            return $"Podcast : \n Titre : {base.Titre}\n Auteur : {Auteur} \n DateDeSortie : {DateDeSortie} \n Description : {Description} \n Chemin : {Chemin} \n";
        }
    }
}
