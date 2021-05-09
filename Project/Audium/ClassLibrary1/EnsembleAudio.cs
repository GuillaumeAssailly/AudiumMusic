using System;
using System.Diagnostics.CodeAnalysis;

namespace Donnees
{
    public class EnsembleAudio : IEquatable<EnsembleAudio>
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
        }

        public string Titre { get; set; }
        public DateTime DateAjout { get; private set; }
        public int Note { get; private set; }
        public string Description { get; private set; }
        public string CheminImage { get; private set; }
        public int CmptEcoute { get; private set; }
        public bool Favori { get; set; }
        public EGenre Genre { get; private set; }

        public void ModifierEnsemble(string Titre, int Note, string Description, string CheminImage, EGenre Genre)
        {
            this.Titre = Titre;
            this.Note = Note;
            this.Description = Description;
            this.CheminImage = CheminImage;
            this.Genre = Genre;
        }

        public bool Equals([AllowNull] EnsembleAudio other)
        {
            return Titre.ToLower().Equals(other.Titre.ToLower());
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
            return Titre.GetHashCode();
        }


        public override string ToString()
        {
            return $"Titre : {Titre}\n Note (sur 5) : {Note}\n Description : {Description} \n Image : {CheminImage} \n Genre : {Genre} \n Date : {DateAjout}";
        }

    }
}
