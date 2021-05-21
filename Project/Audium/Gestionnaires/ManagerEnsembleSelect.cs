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
    public class ManagerEnsembleSelect : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Piste PisteSelect
        {
            get => pisteSelect;
            set
            {
                
            pisteSelect = value;
            OnPropertyChanged(nameof(PisteSelect));
                
            }
        }
        private Piste pisteSelect;

        public Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque;

        public ReadOnlyCollection<Piste> ListeSelect { get; set; }
        private LinkedList<Piste> listeSelect;


        public EnsembleAudio EnsembleSelect
        {
            get => ensembleSelect;
            set
            {
                if (ensembleSelect != value && value != null)
                {
                    ensembleSelect = value;
                    mediatheque.TryGetValue(ensembleSelect, out listeSelect);
                    ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
                    OnPropertyChanged(nameof(EnsembleSelect));
                    OnPropertyChanged(nameof(ListeSelect));
                }
            }
        }
        private EnsembleAudio ensembleSelect;

        public ManagerEnsembleSelect(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque)
        {
            this.mediatheque = mediatheque;
            
            
        }

        public void AjouterMorceau(string titre, string artiste, string chemin)
        {
            int i = 1;
            
            if (string.IsNullOrWhiteSpace(titre))
            {
                throw new ArgumentException("Le titre du morceau n'est pas valide");
            }

           


            Morceau morceau= new(titre,artiste,chemin);

            while (listeSelect.Contains(morceau))
            {
                morceau.Titre = $"{titre} ({i})";
                i++;
            }

            listeSelect.AddLast(morceau);
            mediatheque.TryGetValue(ensembleSelect, out listeSelect);
            ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
            OnPropertyChanged(nameof(ListeSelect));
        }

        public void AjouterStationRadio(string titre, string url)
        {
            int i = 1;

            if (string.IsNullOrWhiteSpace(titre) || string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("Le titre ou l'url de la radio n'est pas valide");
            }

            StationRadio radio = new(titre,url);

            while (listeSelect.Contains(radio))
            {
                radio.Titre = $"{titre} ({i})";
                i++;
            }

            listeSelect.AddLast(radio);
            mediatheque.TryGetValue(ensembleSelect, out listeSelect);
            ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
            OnPropertyChanged(nameof(ListeSelect));
        }

        public void AjouterPodcast(string titre, string description, string auteur, string chemin, DateTime date)
        {
            int i = 1;

            if (string.IsNullOrWhiteSpace(titre))
            {
                throw new ArgumentException("Le titre ou le chemin de la radio n'est pas valide");
            }

            Podcast podcast = new(titre, description, auteur, chemin,date);

            while (listeSelect.Contains(podcast))
            {
                podcast.Titre = $"{titre} ({i})";
                i++;
            }

            listeSelect.AddLast(podcast);
            mediatheque.TryGetValue(ensembleSelect, out listeSelect);
            ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
            OnPropertyChanged(nameof(ListeSelect));
        }

        public bool SupprimerPiste(Piste pisteAsuppr)
        {
            if (pisteAsuppr == null)
            {
                throw new ArgumentException("La piste à supprimer est nulle");
            }
            if (!listeSelect.Contains(pisteAsuppr)) 
            {
                throw new ArgumentException("La piste en argument n'est pas contenue dans la liste");
            }
            if(!listeSelect.Remove(pisteAsuppr))
            {
                return false;
            }
            mediatheque.TryGetValue(ensembleSelect, out listeSelect);
            ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
            OnPropertyChanged(nameof(ListeSelect));
            return true;
        }


        public void ActualiserListe()
        {
            mediatheque.TryGetValue(ensembleSelect, out listeSelect);
            ListeSelect = new ReadOnlyCollection<Piste>(listeSelect.ToList());
            OnPropertyChanged(nameof(ListeSelect));
        }






    }
}
