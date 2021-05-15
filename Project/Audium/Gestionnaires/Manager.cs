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
    public class Manager : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ReadOnlyCollection<EnsembleAudio> ListeFavoris { get; }
        private List<EnsembleAudio> listeFavoris;

        public EnsembleAudio EnsembleSelect { 
            get=>ensembleSelect;
            set
            {
                if (ensembleSelect != value)
                {
                    ensembleSelect = value;
                    Mediatheque.TryGetValue(EnsembleSelect, out listeSelect);
                    ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
                    OnPropertyChanged(nameof(EnsembleSelect));
                    OnPropertyChanged(nameof(ListeSelect));
                }           
            }
        }
        private EnsembleAudio ensembleSelect;

        public ReadOnlyCollection<Piste> ListeSelect { get; set; }
        private LinkedList<Piste> listeSelect;
        
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

            listeGenres = new List<string>
            {
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
            EnsembleSelect = Mediatheque.First().Key;
            
            

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
            EnsembleAudio RAM = new EnsembleAudio("RAM", "Daft Punk", "ram.jpg", EGenre.BANDEORIGINALE, 4);

            LinkedList<Piste> LP1 = new();
            LP1.AddLast(new Morceau("RAM 1","Daft Punk","iafaf",50,DateTime.Now));
            LP1.AddLast(new Piste("RAM 2"));
            LP1.AddLast(new Piste("RAM 3"));
            LP1.AddLast(new Piste("RAM 4"));
            LP1.AddLast(new Piste("RAM 5"));
            this.AjouterEnsemblePiste(RAM, LP1);

            EnsembleAudio HYP = new EnsembleAudio("Hypnoflup", "Stipiflip", "hypnoflip.jpg", EGenre.HIPHOP, 4);
            LinkedList<Piste> LP2 = new();
            LP2.AddLast(new Piste("HYP 1"));
            LP2.AddLast(new Piste("HYP 2"));
            LP2.AddLast(new Piste("HYP 3"));
            LP2.AddLast(new Piste("HYP 4"));
            
            this.AjouterEnsemblePiste(HYP, LP2);

            EnsembleAudio WAG = new EnsembleAudio("Wagner", "Stipiflip", "wagner.jpg", EGenre.CLASSIQUE, 4);
            this.AjouterEnsemblePiste(WAG, LP1);

            EnsembleAudio IAM = new EnsembleAudio("IAM", "Stipiflip", "iam.jpg", EGenre.HIPHOP, 4);
            this.AjouterEnsemblePiste(IAM, LP1);

            ModifierListeFavoris(HYP);
            ModifierListeFavoris(RAM);



        }


    }
}
