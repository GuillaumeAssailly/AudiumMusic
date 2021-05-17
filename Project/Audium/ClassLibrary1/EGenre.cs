using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public enum EGenre  
    {
        AUCUN,
        JAZZ,
        ROCK,
        CLASSIQUE,
        HIPHOP,
        BLUES,
        BANDEORIGINALE

    }

    public static class Genre
    {
        public static string GetString(EGenre genre)
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
                    return "Aucun";
            }
        }

        public static EGenre GetGenre(string genre)
        {
            if (genre.Equals(GetString(EGenre.JAZZ))) return EGenre.JAZZ;
            if (genre.Equals(GetString(EGenre.ROCK))) return EGenre.ROCK;
            if (genre.Equals(GetString(EGenre.CLASSIQUE))) return EGenre.CLASSIQUE;
            if (genre.Equals(GetString(EGenre.HIPHOP))) return EGenre.HIPHOP;
            if (genre.Equals(GetString(EGenre.BLUES))) return EGenre.BLUES;
            if (genre.Equals(GetString(EGenre.BANDEORIGINALE))) return EGenre.BANDEORIGINALE;
            return EGenre.AUCUN;
        }
    }
}
