using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public enum EGenre : 
    {
        JAZZ,
        ROCK,
        CLASSIQUE,
        HIPHOP,
        BLUES,
        BANDEORIGINALE

    }

    public static class Genre
    {
        public static String GetString(this EGenre genre)
        {
            switch (genre)
            {
                case EGenre.JAZZ:
                    return "Jazz";
                case EGenre.ROCK:
                    return "Rock";
                case EGenre.CLASSIQUE:
                    return "Classique";
                case EGenre.HIPHOP:
                    return "Hip-Hop";
                case EGenre.BLUES:
                    return "Blues";
                case EGenre.BANDEORIGINALE:
                    return "Bande Originale";
                default:
                    return "Ce genre n'existe pas";
            }
        }
    }
}
