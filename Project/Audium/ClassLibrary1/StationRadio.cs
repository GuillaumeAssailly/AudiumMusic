using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{

    [DataContract]
    public class StationRadio : Piste
    {
        public StationRadio(string titre, string URL)
            :base(titre,URL)
        {
            Emet = false;
            
        }


        [DataMember(EmitDefaultValue = false)]
        public string AdresseURL { get; private set;  }


        [DataMember(EmitDefaultValue = false)]
        public bool Emet { get; private set; }

        public void ModifierRadio(string titre, string URL)
        {
            base.Titre = titre;
            base.Source = URL;
           
        }

        public override String ToString()
        {
            return $"Radio : \n Titre : {base.Titre}\n AdresseURL : {AdresseURL} \n Emet : {Emet} \n";
        }
    }
}
