using System;
using Donnees;

namespace Test_Piste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe Piste !");
            Piste p1 = new Piste("PisteVide");
            Console.WriteLine(p1);
            Piste NRJ = new StationRadio("NRJ12", "http://wtf");
            Console.WriteLine(NRJ);
        }
    }
}
