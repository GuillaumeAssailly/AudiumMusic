using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Donnees
{
    public class EnsembleAudio : IEquatable<EnsembleAudio>, INotifyPropertyChanged
    {
        public EnsembleAudio(string titre, string description, string cheminImage, EGenre genre,int note)
        {
           
            Titre = titre;
            Description = description;
            CheminImage = cheminImage;
            Genre = genre;
            Note = note;
            DateAjout=DateTime.Now;
            CmptEcoute = 0;
            Favori = false;
         
            Debug.WriteLine(ID);
        }

        public string ID { get; private set; }
        public string Titre { 
             get => titre;
             set {
                titre = value;
                OnPropertyChanged(nameof(Titre));
             }
        }
        private string titre;
        public DateTime DateAjout { get; private set; }
        public int Note { get; set; }
        public string Description { get; private set; }
        public string CheminImage {
            get => cheminImage;
            private set {
                cheminImage = value;
                OnPropertyChanged(nameof(CheminImage)); 
            } 
        }
        private string cheminImage;
        public int CmptEcoute { get; private set; }
        public bool Favori { 
            get => favori; 
            set 
            { 
                favori = value;
                OnPropertyChanged(nameof(Favori));
            } 
        }
        private bool favori;
        public EGenre Genre { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ModifierEnsemble(string Titre, int Note, string Description, string CheminImage, EGenre Genre)
        {
            this.Titre = Titre;
            this.Note = Note;
            this.Description = Description;
            this.CheminImage = CheminImage;
            this.Genre = Genre;
        }

        public void ModifierImage(string imageSource)
        {
            CheminImage = imageSource;
        }

        public bool Equals([AllowNull] EnsembleAudio other)
        {
            return DateAjout.Equals(other.DateAjout);
        }

        public override bool Equals(object obj)
        {
            if  (ReferenceEquals(obj,  null))  return false;
            if  (ReferenceEquals(obj,  this)) return true;

            if  (GetType()  != obj.GetType()) return false;
            return Equals(obj as EnsembleAudio);
        }

        public override int GetHashCode()
        {
            return DateAjout.GetHashCode();
        }


        public override string ToString()
        {
            return $"Titre : {Titre}\n Note (sur 5) : {Note}\n Description : {Description} \n Image : {CheminImage} \n Genre : {Genre} \n Date : {DateAjout}";
        }

        
    }
}
