using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;


namespace Gestionnaires
{
    public partial class Manager
    {
        

        public EnsembleAudio EnsembleLu
        {
            get => ensembleLu;
            set
            {
                if (ensembleLu != value)
                {
                    ensembleLu = value;
                    if (ensembleLu != null) { Mediatheque.TryGetValue(ensembleLu, out Playlist); }
                    if (Playlist != null) { Playlist = new LinkedList<Piste>(Playlist.ToList());  }
                    OnPropertyChanged(nameof(EnsembleLu));
                    OnPropertyChanged(nameof(Playlist));


                }
            }
        }
        private EnsembleAudio ensembleLu;

        public LinkedList<Piste> Playlist;

        public int MediaIndex;

        
    }
}
