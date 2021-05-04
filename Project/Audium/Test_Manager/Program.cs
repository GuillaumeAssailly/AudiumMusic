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
            master.AjouterEnsemblePiste(RAM, LP);
            Console.WriteLine(master);

        }
    }
}
