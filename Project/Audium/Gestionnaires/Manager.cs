using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ReadOnlyCollection<EnsembleAudio> ListeFavoris { get; }
        private List<EnsembleAudio> listeFavoris;

        



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

        public Manager()
        {
           
            CompteurAlbum = 0;
            mediatheque = new Dictionary<EnsembleAudio, LinkedList<Piste>>();
            Mediatheque = new ReadOnlyDictionary<EnsembleAudio, LinkedList<Piste>>(mediatheque);
            ManagerEnsemble = new(mediatheque);
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
            ManagerEnsemble.AjouterMorceau("Allo", "Olla", "/quelquepart/...", DateTime.Now);

            Debug.Write(ManagerEnsemble.mediatheque.Keys.Count);

            foreach (LinkedList<Piste> liste in mediatheque.Values)
            {
                foreach (Piste p in liste)
                {
                    Debug.WriteLine(p.Titre);
                }
            }

        }

     


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

        public void AjouterEnsemblePiste(EnsembleAudio E, LinkedList<Piste>LP)
        {
          
            mediatheque.Add(E,LP);
            
        }

        public EnsembleAudio CreerEnsembleAudio(string titre, string description, string cheminImage, EGenre genre, int note)
        {
            //Finir cette méthode avec un if( Key.Titre n'existe pas dans discothèque) sinon Titre = Titre + "(1);
            EnsembleAudio Nouveau = new(titre, description, cheminImage, genre,note);
            int i = 1;
            while (Mediatheque.ContainsKey(Nouveau))
            {
                Nouveau.Titre = $"{titre} ({i})";
                i++;
            }
            return Nouveau;
        }

      
        public override string ToString()
        {
            return $"Compteur : {CompteurAlbum}\n Médiathèque : {Mediatheque}";
        }

        public void ConfigTest()
        {
            EnsembleAudio RAM = new EnsembleAudio("Random Access Memories", "Daft Punk", "ram.jpg", EGenre.BANDEORIGINALE, 4);

            LinkedList<Piste> LP1 = new();
            LP1.AddLast(new Morceau("Give Life Back to Music","Daft Punk","iafaf",DateTime.Now));
            LP1.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf", DateTime.Now));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf", DateTime.Now));
            this.AjouterEnsemblePiste(RAM, LP1);

            EnsembleAudio HYP = new EnsembleAudio("The Hypnoflip Invasion", "Stipiflip", "hypnoflip.jpg", EGenre.HIPHOP, 4);
            LinkedList<Piste> LP2 = new();
            LP2.AddLast(new Piste("Intro"));
            LP2.AddLast(new Piste("Stupeflip Vite!"));
            LP2.AddLast(new Piste("La Menuiserie"));
            
            
            this.AjouterEnsemblePiste(HYP, LP2);

            EnsembleAudio WAG = new EnsembleAudio("Wagner", "Stipiflip", "wagner.jpg", EGenre.CLASSIQUE, 4);
            LinkedList<Piste> LP3 = new();
            LP3.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf", DateTime.Now));
            LP3.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf", DateTime.Now));
            LP3.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf", DateTime.Now));
            this.AjouterEnsemblePiste(WAG, LP3);

            EnsembleAudio IAM = new EnsembleAudio("IAM", "Stipiflip", "iam.jpg", EGenre.HIPHOP, 4);
            this.AjouterEnsemblePiste(IAM, LP1);

            ModifierListeFavoris(HYP);
            ModifierListeFavoris(RAM);



        }


    }
}
