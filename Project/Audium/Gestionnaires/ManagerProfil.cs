using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;

namespace Gestionnaires
{
    public class ManagerProfil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ManagerProfil()
        {
            Nom = "Nom d'utilisateur";
            CheminImage = @"\img\pp.png\";
            CouleurTheme = "Blue";
            CheminBaseDonnees = null;
        }

      

        public string Nom
        {
            get => nom;
            set
            {
                if (nom != value)
                {
                    nom = value;
                    OnPropertyChanged(nameof(Nom)); 
                }
            }
        }
        private string nom;

        public string CheminImage {
            get => cheminImage;
            set
            {
                if (cheminImage != value)
                {
                    cheminImage = value;
                    OnPropertyChanged(nameof(CheminImage));
                }
            }
        }
        private string cheminImage;

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
