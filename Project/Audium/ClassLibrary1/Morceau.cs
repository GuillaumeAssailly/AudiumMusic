using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class Morceau : Piste
    {
        public Morceau(string titre, string artiste, string chemin, int duree, DateTime dateDeSortie)
            :base($"Track : {titre}")
        {
            DateDeSortie = dateDeSortie;
            Artiste = artiste;
            Chemin = chemin;
            Duree = duree;
        }

        public DateTime DateDeSortie { get; private set; }
        public string Artiste { get; private set; }
        public string Chemin { get; private set;  }
        public int Duree { get; private set; }

        public void ModifierMorceau(string titre, string chemin, string artiste, DateTime dateDeSortie)
        {
            base.Titre = $"Track : {titre}";
            DateDeSortie = dateDeSortie;
            Artiste = artiste;
            Chemin = chemin;
        }

        public override String ToString()
        {
            return $"Morceau : \n Titre : {base.Titre}\n Date de Sortie : {DateDeSortie} \n Artiste : {Artiste} \n Chemin : {Chemin}";
        }
    }
}
