using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Donnees;

namespace Gestionnaires
{
    [DataContract]
    public class ManagerProfil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ManagerProfil()
        {
            Nom = "Nom d'utilisateur";
            CheminImage = @"..\icondefault\pp.png";
            CouleurTheme = "Blue";
            CheminBaseDonnees = null;
        }



        [DataMember]
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


        [DataMember]
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


        [DataMember]
        public string CouleurTheme { get; private set; }

        [DataMember]
        public string CheminBaseDonnees { get => cheminBaseDonnees;
            set 
            {
                if(value != null)
                {
                    cheminBaseDonnees = value;
                    OnPropertyChanged(nameof(CheminBaseDonnees));
                }
            }
        }
        private string cheminBaseDonnees;
        

        
        
      
        
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
