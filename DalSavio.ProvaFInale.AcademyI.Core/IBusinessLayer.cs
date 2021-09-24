using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSavio.ProvaFInale.AcademyI.Core
{
   public interface IBusinessLayer
    {
       List<Spese> CalcolaRimborso(List<Spese> spese);
        List<Spese> ScegliApprovatore();
        Dipendenti RecuperaDipendente();
        void ScriviSuFile(Dipendenti dipendente, List<Spese> spese2);
    }
}
