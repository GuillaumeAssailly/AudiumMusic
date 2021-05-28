using Donnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContractPersistance
{

    [DataContract]
    class DataToPersist
    {

        [DataMember (Order=0)]
        public Dictionary<EnsembleAudio, LinkedList<Piste>> Mediatheque { get; set; } = new();


        [DataMember(Order = 1)]
        public List<EnsembleAudio> ListeFav { get; set; } = new();

      
    }
}
