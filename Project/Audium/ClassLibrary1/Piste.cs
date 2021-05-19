using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class Piste : IEquatable<Piste>
    {
        public Piste(string titre)
        {
            Titre = titre;
            CmptEcoute = 0;
        }

        public int CmptEcoute { get; protected set; }
        public string Titre { get; set; }

        public override String ToString()
        {
            return $"Piste : \n Titre : {Titre}\n ";
        }


        public bool Equals([AllowNull] Piste other)
        {
            return Titre.ToLower().Equals(other.Titre.ToLower());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;

            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Piste);
        }

        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }



    }
}
