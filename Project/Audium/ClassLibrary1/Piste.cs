using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class Piste
    {
        public Piste(string titre)
        {
            Titre = titre;
            CmptEcoute = 0;
        }

        public int CmptEcoute { get; protected set; }
        public string Titre { get; protected set; }

        public override String ToString()
        {
            return $"Piste : \n Titre : {Titre}\n ";
        }
    }
}
