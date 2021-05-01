using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    public class StationRadio : Piste
    {
        public StationRadio(string titre, string URL, bool emet)
            :base($"Radio : {titre}")
        {
            AdresseURL = URL;
            Emet = emet;
        }

        public string AdresseURL { get; private set;  }

        public bool Emet { get; private set; }

        public void ModifierRadio(string titre, string URL, bool emet)
        {
            base.Titre = $"Radio: {titre}";
            AdresseURL = URL;
            Emet = emet;
        }

        public override String ToString()
        {
            return $"Radio : \n Titre : {base.Titre}\n AdresseURL : {AdresseURL} \n Emet : {Emet} \n";
        }
    }
}
