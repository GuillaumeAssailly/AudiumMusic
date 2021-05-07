using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;

namespace Gestionnaires
{
    public class ManagerProfil
    {
        public ReadOnlyCollection<EnsembleAudio> ListeFavoris { get; }
        private List<EnsembleAudio> listeFavoris;

        public ManagerProfil()
        {
            Nom = "Nom d'utilisateur";
            CheminImage = null;
            CouleurTheme = "Blue";
            CheminBaseDonnees = null;
            listeFavoris = new List<EnsembleAudio>
            {
                new EnsembleAudio("titreosef","description osef", "sdfd", EGenre.CLASSIQUE),
                new EnsembleAudio("rgergfe","desc","zdfezffz",EGenre.JAZZ)
            };

            ListeFavoris = new ReadOnlyCollection<EnsembleAudio>(listeFavoris);


        }

        public string Nom { get; private set; }
        public string CheminImage { get; private set; }
        public string CouleurTheme { get; private set; }
        public string CheminBaseDonnees { get; private set; }
       

        
        public void ModifierListeFavoris(EnsembleAudio A)
        {
            if (A.Favori == false) 
            {
                listeFavoris.Add(A);
            } 
            else
                listeFavoris.Remove(A);
            A.Favori = !A.Favori;
        }
      
        
        public void ModifierProfil(string Nom, string CheminImage)
        {
            this.Nom = Nom;
            this.CheminImage = CheminImage;
           
        }

        public void ModifierParamètres(string CouleurTheme, string CheminBaseDonnees)
        {
            this.CouleurTheme = CouleurTheme;
            this.CheminBaseDonnees = CheminBaseDonnees;
        }

        override
        public string ToString()
        {
            return $"Profil : \n Nom d'utilisateur : {Nom} \n Image : {CheminImage} \n Thème : {CouleurTheme} \n Chemin de la base de données : {CheminBaseDonnees} \n Liste favoris : {listeFavoris}";
        }
    }
}
