using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class Morceau
    {
        public Morceau(string artiste, string chemin, int duree)
        {
            Artiste = artiste;
            Chemin = chemin;
            Duree = duree;
        }

        public string Artiste { get; private set; }
        public string Chemin { get; private set;  }
        public int Duree { get; private set; }

    }
}
