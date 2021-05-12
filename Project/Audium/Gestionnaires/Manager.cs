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
                    OnPropertyChanged(nameof(EnsembleSelect));
                }           
            }
        }
        private EnsembleAudio ensembleSelect;

        
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


            listeFavoris = new List<EnsembleAudio>
            {
                new EnsembleAudio("The Hypnoflip Invasion","Fin 2010 le groupe propose via son site internet d'acquérir en pré-commande un pack incluant The Hypnoflip Invasion en version collector, le picture-disc Terror Maxi et divers goodies1. Un peu plus de 1000 fans répondent à l'appel2 et l'album peut être mixé aux Studios Ferber par René Ameline3.Une réédition limitée, incluant deux morceaux supplémentaires, est sortie le 19 octobre 2011. ", "hypnoflip.jpg", EGenre.HIPHOP,5),
                new EnsembleAudio("Random Access Memories Rare Version","Random Access Memories est le quatrième et dernier album studio du groupe français Daft Punk, sorti officiellement le 17 mai 2013n 1. Il est publié par Daft Life Limited, une filiale de Columbia Records. L'album comprend des collaborations avec plusieurs artistes tels que Nile Rodgers, Paul Williams, Giorgio Moroder, Pharrell Williams, Todd Edwards, DJ Falcon, Chilly Gonzales, Panda Bear et Julian Casablancas et se caractérise, en tant qu'hommage au son des années 1970, par le parti pris d'utiliser des musiciens jouant sur des instruments acoustiques ou électro-acoustiques (guitare, basse, batterie, piano, etc.) en limitant l'usage des machines électroniques","ram.jpg",EGenre.JAZZ,4)
            };

            ListeFavoris = new ReadOnlyCollection<EnsembleAudio>(listeFavoris);
            EnsembleSelect = ListeFavoris[0];

            

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
            EnsembleAudio RAM = new EnsembleAudio("RAM", "Daft Punk", "ram.jpg", EGenre.JAZZ, 4);

            LinkedList<Piste> LP = new();
            LP.AddLast(new Piste("Piste 1"));
            LP.AddLast(new Piste("Piste 2"));
            LP.AddLast(new Piste("Piste 3"));
            LP.AddLast(new Piste("Piste 4"));
            LP.AddLast(new Piste("Piste 5"));
            this.AjouterEnsemblePiste(RAM, LP);

            EnsembleAudio HYP = new EnsembleAudio("Hypnoflup", "Stipiflip", "hypnoflip.jpg", EGenre.JAZZ, 4);
            this.AjouterEnsemblePiste(HYP, LP);

            EnsembleAudio WAG = new EnsembleAudio("Wagner", "Stipiflip", "wagner.jpg", EGenre.JAZZ, 4);
            this.AjouterEnsemblePiste(WAG, LP);

            EnsembleAudio IAM = new EnsembleAudio("IAM", "Stipiflip", "iam.jpg", EGenre.JAZZ, 4);
            this.AjouterEnsemblePiste(IAM, LP);





        }


    }
}
