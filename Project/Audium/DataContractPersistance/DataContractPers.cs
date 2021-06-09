using Donnees;
using Gestionnaires;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using System.Xml;

namespace DataContractPersistance 
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContractPers : IPersistanceManager
    {
        public string FilePath  => Path.Combine(Directory.GetCurrentDirectory(), RelativePath);

         
        public string FileName { get; set; } = "audium.xml";


        public string RelativePath { get; set; } = "..\\XML";

        protected string PersFile => Path.Combine(FilePath, FileName);

        protected XmlObjectSerializer Serializer = new DataContractSerializer(typeof(DataToPersist),
                                                                           new DataContractSerializerSettings()
                                                                           {
                                                                               PreserveObjectReferences = true
                                                                           });

       
        
        public virtual (Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP) ChargeDonnees()
        {

            DataToPersist data = new DataToPersist();


            if (!File.Exists(PersFile))
            {
                //throw new FileNotFoundException("the persistance file is missing");
                Directory.CreateDirectory(FilePath);

               
                    var settings = new XmlWriterSettings() { Indent = true };
                    using (TextWriter tw = File.CreateText(PersFile))
                    {
                        using (XmlWriter writer = XmlWriter.Create(tw, settings))
                        {
                            Serializer.WriteObject(writer, data);
                        }
                    }
                
            }

         


          

            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }


            return (data.Mediatheque, data.ListeFav, data.MP);
        }

        public virtual void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP)
        {
          


            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.Mediatheque = mediatheque;
            data.ListeFav.AddRange(listeFavoris);
            data.MP = MP;

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
