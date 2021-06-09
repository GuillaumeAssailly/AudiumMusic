using Donnees;
using Gestionnaires;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using DataContractPersistance;
using Newtonsoft.Json.Serialization;

namespace JsonPersistance
{
    public class JsonPers : IPersistanceManager
    {

        public string FilePath => Path.Combine(Directory.GetCurrentDirectory(), RelativePath);

        public string FileName { get; set; } = "audium.json";

        public string RelativePath { get; set; } = "..\\JSON";

        protected string PersFile => Path.Combine(FilePath, FileName);


        public (Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP) ChargeDonnees()
        {
            if (!File.Exists(PersFile))
            {
                //throw new FileNotFoundException("the persistance file is missing");
                Directory.CreateDirectory(FilePath);
               
                    DataToPersist Vide = new();
                    var defaut = JsonConvert.SerializeObject(Vide, new JsonSerializerSettings()
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All,
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented,
                        ContractResolver = new DictionaryAsArrayResolver()
                    });
                    File.WriteAllText(PersFile, defaut);


                    return (Vide.Mediatheque, Vide.ListeFav, Vide.MP);
                

            }
            var json = File.ReadAllText(PersFile);
            var data = JsonConvert.DeserializeObject<DataToPersist>(json, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                ContractResolver = new DictionaryAsArrayResolver()
            });
            return (data.Mediatheque, data.ListeFav, data.MP);
        }

        public void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new();
            
            data.Mediatheque = mediatheque;
            data.ListeFav = listeFavoris;
            data.MP = MP;

            /*
            EnsembleAudio testEA = new EnsembleAudio("test", "desc", "image", EGenre.AUCUN, 3);
            LinkedList<Piste> testlp = new();
            data.Mediatheque.Add(testEA,testlp);
            data.ListeFav.Add(testEA);
            */
            /*
            JsonSerializer serializer = new();
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.Formatting = Formatting.Indented;
            
            using (StreamWriter stream = new(PersFile))
            {
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    serializer.Serialize(writer, data);
                    
                }
            }
            */
            //DefaultContractResolver contractResolver = new() { NamingStrategy = new CamelCaseNamingStrategy() { ProcessDictionaryKeys=false } };
            var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                ContractResolver = new DictionaryAsArrayResolver()
            });
            File.WriteAllText(PersFile,json);
        }
    }
}
