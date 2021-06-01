using Donnees;
using Gestionnaires;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataContractPersistance
{
    public class DataContractPersJSON : DataContractPers
    {


      

        public DataContractPersJSON()
        {
            RelativePath = "..\\JSON";
            FileName = "audium.json";
            Serializer = new DataContractJsonSerializer(typeof(DataToPersist));
             

        }

        public override void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP)
        {

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.Mediatheque = mediatheque;
            data.ListeFav.AddRange(listeFavoris);
            data.MP = MP;

            using(Stream writer = File.Create(PersFile))
            {
                Serializer.WriteObject(writer, data);
            }
        }
    }
}
