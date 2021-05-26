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
            :base(titre,chemin)
        {
            DateDeSortie = datedesortie;
            Description = description;
            Auteur = auteur;
           
        }

        public DateTime DateDeSortie { get; set; }
        public string Description { get;  set; }
        public string Auteur { get;  set; }
       
        public void ModifierPodcast(string titre, string description, string chemin, string auteur, DateTime dateDeSortie)
        {
            base.Titre = titre;
            base.Source = chemin;
            DateDeSortie = dateDeSortie;
            Description = description;
            Auteur = auteur;
          
        }


        public override String ToString()
        {
            return $"Podcast : \n Titre : {base.Titre}\n Auteur : {Auteur} \n DateDeSortie : {DateDeSortie} \n Description : {Description} \n Chemin : {base.Source} \n";
        }
    }
}
