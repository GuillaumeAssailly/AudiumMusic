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

        public void AjouterMorceau(string titre, string artiste, string chemin, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(titre) || string.IsNullOrWhiteSpace(chemin))
            {
                throw new ArgumentException("Le titre ou le chemin du morceau n'est pas valide");
            }
                
            Morceau morceau= new(titre,artiste,chemin,date);

            listeSelect.AddLast(morceau);
            
        }
    }
}
