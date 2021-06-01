using Donnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaires
{
    public interface IPersistanceManager
    {
        (Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP)ChargeDonnees();

        void SauvegardeDonnees(Dictionary<EnsembleAudio, LinkedList<Piste>> mediatheque, List<EnsembleAudio> listeFavoris, ManagerProfil MP);
    }
}
