using Donnees;
using Gestionnaires;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public (Dictionary<EnsembleAudio, LinkedList<Piste>>mediatheque, List<EnsembleAudio>listeFavoris) ChargeDonnees()
        {
            var donnees = ChargeDictionnaire();
            return donnees;
        }

        public void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris)
        {
            Debug.WriteLine("Sauvegarde en cours");
        }

        private (Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris) ChargeDictionnaire()
        {
            Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque = new();
            List<EnsembleAudio> listeFavoris = new();

            EnsembleAudio RAM = new EnsembleAudio("Random Access Memories", "Daft Punk", "ram.jpg", EGenre.BANDEORIGINALE, 3);
            LinkedList<Piste> LP1 = new();
            LP1.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            LP1.AddLast(new Podcast("Interview exclusive de Guy-Man", "Interview données à France Inter le 14 juin 2012", "France Inter", "", DateTime.Now));
            mediatheque.Add(RAM, LP1);



            EnsembleAudio HYP = new EnsembleAudio("The Hypnoflip Invasion", "Stipiflip", "hypnoflip.jpg", EGenre.HIPHOP, 5);
            LinkedList<Piste> LP2 = new();
            LP2.AddLast(new Morceau("Intro", "Stupeflip", ""));
            LP2.AddLast(new Morceau("Stupeflip Vite!", "Stupeflip", ""));
            LP2.AddLast(new Morceau("La Menuiserie", "Stupeflip", ""));
            mediatheque.Add(HYP, LP2);


            EnsembleAudio WAG = new EnsembleAudio("Wagner", "Stipiflip", "wagner.jpg", EGenre.CLASSIQUE, 2);
            LinkedList<Piste> LP3 = new();
            LP3.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf"));
            LP3.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP3.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            mediatheque.Add(WAG, LP3);

            EnsembleAudio IAM = new EnsembleAudio("IAM", "Stipiflip", "iam.jpg", EGenre.HIPHOP, 3);
            LinkedList<Piste> LP4 = new();
            LP4.AddLast(new Morceau("Give Life Back to Music", "Daft Punk", "iafaf"));
            LP4.AddLast(new Morceau("The Game of Love", "Daft Punk", "iafaf"));
            LP4.AddLast(new Morceau("Giorgio by Moroder", "Daft Punk", "iafaf"));
            mediatheque.Add(IAM, LP4);

            RAM.Favori=true;
            HYP.Favori = true;
            listeFavoris.Add(RAM);
            listeFavoris.Add(HYP);

            return (mediatheque,listeFavoris);
        }
    }
}
