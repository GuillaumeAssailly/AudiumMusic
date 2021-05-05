using System;
using System.Collections.Generic;
using Donnees;
using Gestionnaires;



namespace Test_URecherche
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de l'utilitaire de recherche");
            Manager master = new();
            EnsembleAudio e1 = new EnsembleAudio("RAM", "Album de Daft Punk", "img.png", EGenre.GenreMusique.CLASSIQUE);
            LinkedList<Piste> le1 = new();
            for(int i = 0; i<10; i++)
            {
                le1.AddLast(new Piste($"test {i}"));
            }
            EnsembleAudio e2 = new EnsembleAudio("ROUM", "Album de Daft Punk", "img.png", EGenre.GenreMusique.JAZZ);
            LinkedList<Piste> le2 = new();
            for (int i = 0; i < 10; i++)
            {
                le1.AddLast(new Piste($"test {i}"));
            }
            master.AjouterEnsemblePiste(e1, le1);
            master.AjouterEnsemblePiste(e2, le2);
            
            Dictionary<EnsembleAudio,LinkedList<Piste>> res = URecherche.RechercherParGenre(EGenre.GenreMusique.JAZZ);

            Console.WriteLine("Médiathèque : ");

            foreach(KeyValuePair<EnsembleAudio,LinkedList<Piste>> cle in Manager.Mediatheque)
            {
                Console.WriteLine($"Clé : {cle.Key} Valeur : {cle.Value}");
            }

            Console.WriteLine("\nRésultat");

            foreach (KeyValuePair<EnsembleAudio, LinkedList<Piste>> cle in res)
            {
                Console.WriteLine($"Clé : {cle.Key} Valeur : {cle.Value}");
            }

            Console.WriteLine("\nRecherche par mot clé");
            Dictionary<EnsembleAudio, LinkedList<Piste>> res2 = URecherche.RechercherParMotCle("rA");

            foreach (KeyValuePair<EnsembleAudio, LinkedList<Piste>> cle in res2)
            {
                Console.WriteLine($"Clé : {cle.Key} Valeur : {cle.Value}");
            }




        }
    }

}
