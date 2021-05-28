using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Donnees
{
    [DataContract]
    public class Morceau : Piste
    {
        public Morceau(string titre, string artiste, string chemin)
            :base(titre,chemin)
        {
           
            Artiste = artiste;
           
        }


        [DataMember(EmitDefaultValue = false)]
        public string Artiste { get; set; }
       
         
        public void ModifierMorceau(string titre, string chemin, string artiste)
        {
            base.Titre = titre;
            base.Source = chemin;
            Artiste = artiste;
        }

        public override String ToString()
        {
            return $"Morceau : \n Titre : {base.Titre}\nArtiste : {Artiste} \n Chemin : {base.Source}";
        }
    }
}
