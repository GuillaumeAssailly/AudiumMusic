using Donnees;
using Gestionnaires;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractPersistance 
{
    public class DataContractPers : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..\\XML");

         
        public string FileName { get; set; } = "audium.xml";


        string PersFile => Path.Combine(FilePath, FileName);

        private DataContractSerializer Serializer = new DataContractSerializer(typeof(DataToPersist),
                                                                           new DataContractSerializerSettings()
                                                                           {
                                                                               PreserveObjectReferences = true
                                                                           });

        public (Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris) ChargeDonnees()
        {
            if(!File.Exists(PersFile))
            {
                throw new FileNotFoundException("the persistance file is missing");
            }

         


            DataToPersist data = new DataToPersist();

            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }


            return (data.Mediatheque, data.ListeFav);
        }

        public void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris)
        {
          


            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.Mediatheque = mediatheque;
            data.ListeFav.AddRange(listeFavoris);


            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        



        }
    }
}
