using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;


namespace Gestionnaires
{
    public partial class Manager : INotifyPropertyChanged
    {

        public ManagerEnsembleSelect ManagerEnsemble;
        public ManagerProfil ManagerProfil;


        public event PropertyChangedEventHandler PropertyChanged;
  
        public void OnPropertyChanged(string propertyName) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

     
        public ReadOnlyCollection<EnsembleAudio> ListeFavoris { get; set; }
        private List<EnsembleAudio> listeFavoris;

        public void ModifierListeFavoris(EnsembleAudio A)
        {
            Debug.WriteLine(mediatheque.FirstOrDefault().Key.Favori);
            if (A.Favori == false)
            {
                listeFavoris.Add(A);
                
            }
            else
            {
                listeFavoris.Remove(A);
            }
            
            ListeFavoris = new ReadOnlyCollection<EnsembleAudio>(listeFavoris);
            OnPropertyChanged(nameof(ListeFavoris));
            A.Favori = !A.Favori;
           
        }




        public string GenreSelect
        {
            get => genreSelect;
            set
            {
                if (genreSelect != value)
                {
                    genreSelect = value;
                    OnPropertyChanged(nameof(GenreSelect));
                    OnPropertyChanged(nameof(Mediatheque));
                }
            }
        }
        private string genreSelect;



       
        
        public ReadOnlyCollection<string> ListeGenres { get; }
        private List<string> listeGenres;


        public static int CompteurAlbum;


        public ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>> Mediatheque { get; }
        private Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque; 
       

        public ObservableCollection<EnsembleAudio> ListeClé 
        {
            get => listeClé;
            set
            {
                listeClé = value;
                OnPropertyChanged(nameof(ListeClé));
            }
        }
        private ObservableCollection<EnsembleAudio> listeClé;


        public Manager()
        {
           
            CompteurAlbum = 0;
            mediatheque = new Dictionary<EnsembleAudio, LinkedList<Piste>>();
            Mediatheque = new ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>>(mediatheque);
           
          
            ManagerEnsemble = new(mediatheque);
            ManagerProfil = new();
            listeGenres = new List<string>
            {
                Genre.GetString(EGenre.AUCUN),
                Genre.GetString(EGenre.BANDEORIGINALE),
                Genre.GetString(EGenre.BLUES),
                Genre.GetString(EGenre.CLASSIQUE),
                Genre.GetString(EGenre.HIPHOP),
                Genre.GetString(EGenre.JAZZ),
                Genre.GetString(EGenre.ROCK)
            };

            ListeGenres = new ReadOnlyCollection<string>(listeGenres);


            listeFavoris = new List<EnsembleAudio>();
            ListeFavoris = new ReadOnlyCollection<EnsembleAudio>(listeFavoris);

            ConfigTest();
            

            GenreSelect = "Aucun";
            ManagerEnsemble.EnsembleSelect = mediatheque.FirstOrDefault().Key;
      


            listeClé = new(Mediatheque.Keys);
            ListeClé = new(listeClé);
          
         

        }

     

        
     

        public void AjouterEnsemblePiste(EnsembleAudio NouvelEnsembleAudio, LinkedList<Piste>NouvelleListePiste)
        {
            mediatheque.Add(NouvelEnsembleAudio, NouvelleListePiste);
            listeClé?.Add(NouvelEnsembleAudio);
            //GenreSelect = Genre.GetString(EGenre.BANDEORIGINALE);
            //GenreSelect = Genre.GetString(EGenre.AUCUN);
            OnPropertyChanged(nameof(Mediatheque));
        }

        public EnsembleAudio CreerEnsembleAudio(string titre)
        {
            //Finir cette méthode avec un if( Key.Titre n'existe pas dans discothèque) sinon Titre = Titre + "(1);
            EnsembleAudio NouvelEnsembleAudio = new(titre, null, "default.png", EGenre.AUCUN, 0);
            return NouvelEnsembleAudio;
        }

      
        public override string ToString()
        {
            return $"Compteur : {CompteurAlbum}\n Médiathèque : {Mediatheque}";
        }

        public void ConfigTest()
        {
            EnsembleAudio RAM = new EnsembleAudio("Random Access Memories", "Daft Punk", "ram.jpg", EGenre.BANDEORIGINALE, 3);

            LinkedList<Piste> LP1 = new();
            LP1.AddLast(new Morceau("Give Life Back to Music","Daft Punk","iafaf"));
            LP1.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Podcast("Interview exclusive de Guy-Man", "Interview données à France Inter le 14 juin 2012", "France Inter", "", DateTime.Now));
            this.AjouterEnsemblePiste(RAM, LP1);

            EnsembleAudio HYP = new EnsembleAudio("The Hypnoflip Invasion", "Stipiflip", "hypnoflip.jpg", EGenre.HIPHOP, 5);
            LinkedList<Piste> LP2 = new();
            LP2.AddLast(new Morceau("Intro","Stupeflip",""));
            LP2.AddLast(new Morceau("Stupeflip Vite!","Stupeflip",""));
            LP2.AddLast(new Morceau("La Menuiserie", "Stupeflip", ""));
            
            
            this.AjouterEnsemblePiste(HYP, LP2);

            EnsembleAudio WAG = new EnsembleAudio("Wagner", "Stipiflip", "wagner.jpg", EGenre.CLASSIQUE, 2);
            LinkedList<Piste> LP3 = new();
            LP3.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf"));
            LP3.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP3.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            this.AjouterEnsemblePiste(WAG, LP3);

            EnsembleAudio IAM = new EnsembleAudio("IAM", "Stipiflip", "iam.jpg", EGenre.HIPHOP, 3);
            LinkedList<Piste> LP4 = new();
            LP4.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf"));
            LP4.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP4.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            this.AjouterEnsemblePiste(IAM, LP4);

            ModifierListeFavoris(HYP);
            ModifierListeFavoris(RAM);

            

        }


    }
}
