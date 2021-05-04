using System;

namespace Donnees
{
    public class EnsembleAudio
    {
        public EnsembleAudio(string titre, string description, string cheminImage, EGenre.GenreMusique genre)
        {
            Titre = titre;
            Description = description;
            CheminImage = cheminImage;
            Genre = genre;
            DateAjout=DateTime.Now;
            CmptEcoute = 0;
            Favori = false;
        }

        public string Titre { get; private set; }
        public DateTime DateAjout { get; private set; }
        public int Note { get; private set; }
        public string Description { get; private set; }
        public string CheminImage { get; private set; }
        public int CmptEcoute { get; private set; }
        public bool Favori { get; set; }
        public EGenre.GenreMusique Genre { get; private set; }

        public void ModifierEnsemble(string Titre, int Note, string Description, string CheminImage, EGenre.GenreMusique Genre)
        {
            this.Titre = Titre;
            this.Note = Note;
            this.Description = Description;
            this.CheminImage = CheminImage;
            this.Genre = Genre;
        }

        override
        public string ToString()
        {
            return $"Titre : {Titre}\n Note (sur 5) : {Note}\n Description : {Description} \n Image : {CheminImage} \n Genre : {Genre}";
        }
    }
}
