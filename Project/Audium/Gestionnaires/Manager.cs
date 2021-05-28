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
        /// <summary>
        /// Dépendance vers le gestionnaire de persistance
        /// </summary>
        public IPersistanceManager Persistance { get; private set; }

        public void ChargeDonnees()
        {
            var donnees = Persistance.ChargeDonnees();
            mediatheque = donnees.mediatheque;
            listeFavoris = donnees.listeFavoris;
            foreach(EnsembleAudio ensAudio in mediatheque.Keys)
            {
                listeClé.Add(ensAudio);
            }
        }

        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(mediatheque, listeFavoris);
        }

        public ManagerEnsembleSelect ManagerEnsemble;
        public ManagerProfil ManagerProfil;


        public event PropertyChangedEventHandler PropertyChanged;
  
        public void OnPropertyChanged(string propertyName) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

     
        public ReadOnlyCollection<EnsembleAudio> ListeFavoris { get; set; }
        private List<EnsembleAudio> listeFavoris;

        public void ModifierListeFavoris(EnsembleAudio A)
        {
           
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




        public EGenre GenreSelect
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
        private EGenre genreSelect;



       
        
        public ReadOnlyCollection<EGenre> ListeGenres { get; }
        private List<EGenre> listeGenres;


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


        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
            CompteurAlbum = 0;
            mediatheque = new Dictionary<EnsembleAudio, LinkedList<Piste>>();
            listeClé = new();
            listeFavoris = new List<EnsembleAudio>();
            ChargeDonnees();
            ListeClé = new(listeClé);
            ListeFavoris = new ReadOnlyCollection<EnsembleAudio>(listeFavoris);
            Mediatheque = new ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>>(mediatheque);
           
          
            ManagerEnsemble = new(mediatheque);
            ManagerProfil = new();
            listeGenres = new List<EGenre>
            {
                EGenre.AUCUN,
                EGenre.BANDEORIGINALE,
                EGenre.BLUES,
                EGenre.CLASSIQUE,
                EGenre.HIPHOP,
                EGenre.JAZZ,
                EGenre.ROCK
            };

            ListeGenres = new ReadOnlyCollection<EGenre>(listeGenres);


            
            



            GenreSelect = EGenre.AUCUN;
            ManagerEnsemble.EnsembleSelect = mediatheque.FirstOrDefault().Key;
      


            

            
            
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


        public void SupprimerEnsembleAudio(EnsembleAudio EnsembleASuppr)
        {
            try
            {
                mediatheque.Remove(EnsembleASuppr);
                ListeClé.Remove(EnsembleASuppr);
                if (EnsembleASuppr.Favori == true)
                {
                    ModifierListeFavoris(EnsembleASuppr);
                }
                if (Mediatheque.Count == 0 && ListeFavoris.Count == 0)
                {
                   
                  EnsembleLu = null;
                  Playlist = null;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            return $"Compteur : {CompteurAlbum}\n Médiathèque : {Mediatheque}";
        }

 

    }
}
