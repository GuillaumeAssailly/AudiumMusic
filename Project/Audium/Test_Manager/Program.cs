using System;
using System.Collections.Generic;
using Donnees;
using Gestionnaires;



namespace Test_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager master = new();
            EnsembleAudio RAM = new EnsembleAudio("RAM", "Daft Punk", "img/cool.png", EGenre.GenreMusique.JAZZ);
            Piste p1 = new Piste("Piste 1");
            Piste p2 = new Piste("Piste 2");
            Piste p3 = new Piste("Piste 3");
            Piste p4 = new Piste("Piste 4");
            Piste p5 = new Piste("Piste 5");
            Piste p6 = new Piste("Piste 6");
            LinkedList<Piste> LP = new();
            LP.AddLast(p1);
            LP.AddLast(p2);
            LP.AddLast(p3);
            LP.AddLast(p4);
            LP.AddLast(p5);
            LP.AddLast(p6);
            Manager.AjouterEnsemblePiste(RAM, LP);
            Console.WriteLine(master);



            EnsembleAudio test = Manager.CreerEnsembleAudio("HypnoFlip", "Album de Stupeflip", "/dev/null", EGenre.GenreMusique.HIPHOP);
            Manager.AjouterEnsemblePiste(test, LP);
            EnsembleAudio test1 = Manager.CreerEnsembleAudio("HypnooFlip", "Album de Stapeflip", "/dev/null", EGenre.GenreMusique.HIPHOP);
            Manager.AjouterEnsemblePiste(test1, LP);
            EnsembleAudio test2 = Manager.CreerEnsembleAudio("HypnoFlip", "Album de Stepeflip", "/dev/null", EGenre.GenreMusique.HIPHOP);
            Manager.AjouterEnsemblePiste(test2, LP);
            EnsembleAudio test3 = Manager.CreerEnsembleAudio("HypnoFlip", "Album de Stipeflip", "/dev/null", EGenre.GenreMusique.HIPHOP);
            Manager.AjouterEnsemblePiste(test3, LP);
            EnsembleAudio test4 = Manager.CreerEnsembleAudio("HypnoFlip", "Album de Stopeflip", "/dev/null", EGenre.GenreMusique.HIPHOP);
            Manager.AjouterEnsemblePiste(test4, LP);

            Console.WriteLine(test);
            Console.WriteLine(test1);
            Console.WriteLine(test2);
            Console.WriteLine(test3);
            Console.WriteLine(test4);
            

        }
    }
}
