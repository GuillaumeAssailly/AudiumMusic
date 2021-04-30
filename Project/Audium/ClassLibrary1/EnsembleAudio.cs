using System;

namespace Donnees
{
    public class EnsembleAudio
    {
        public EnsembleAudio(string titre, string description, string cheminImage, EGenre genre)
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
        public EGenre Genre { get; private set; }

    }
}
