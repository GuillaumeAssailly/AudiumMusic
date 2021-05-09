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
        
        public ManagerProfil()
        {
            Nom = "Nom d'utilisateur";
            CheminImage = null;
            CouleurTheme = "Blue";
            CheminBaseDonnees = null;
           

        }

      

        public string Nom { get; private set; }
        public string CheminImage { get; private set; }
        public string CouleurTheme { get; private set; }
        public string CheminBaseDonnees { get; private set; }
        

        
        
      
        
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
            return $"Profil : \n Nom d'utilisateur : {Nom} \n Image : {CheminImage} \n Thème : {CouleurTheme} \n Chemin de la base de données : {CheminBaseDonnees} \n";
        }
    }
}
