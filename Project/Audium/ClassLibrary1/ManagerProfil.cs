using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class ManagerProfil
    {
        public ManagerProfil()
        {
            Nom = "Nom d'utilisateur";
            CheminImage = null;
            CouleurTheme = "Blue";
            CheminBaseDonnees = null;
            ListFavoris = new List<EnsembleAudio>();
        }

        public string Nom { get; private set; }
        public string CheminImage { get; private set; }
        public string CouleurTheme { get; private set; }
        public string CheminBaseDonnees { get; private set; }
        public List<EnsembleAudio> ListFavoris { get; private set; }

        public void ModifierListeFavoris(EnsembleAudio A)
        {
            if (A.Favori == false) 
            {
                ListFavoris.Add(A);
            } 
            else
                ListFavoris.Remove(A);
            A.Favori = !A.Favori;
        }
        public void RetirerDesFavoris(EnsembleAudio A)
        {
            if(A.Favori==true)
            ListFavoris.Remove(A);
        }
    }
}
