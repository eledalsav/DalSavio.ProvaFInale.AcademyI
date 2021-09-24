using DalSavio.ProvaFInale.AcademyI.AdoRepository;
using DalSavio.ProvaFInale.AcademyI.Core;
using System;
using System.Collections.Generic;

namespace DalSavio.ProvaFInale.AcademyI.ConsoleAppDipendente
{
    class Program
    {
        private static readonly Core.IBusinessLayer bl = new Core.BusinessLayer(new RepositoryDipendenti(), new RepositorySpese());
        static void Main(string[] args)
        {
            try
            {
                List<Spese> spese = bl.ScegliApprovatore();
                List<Spese> spese2 = bl.CalcolaRimborso(spese);
                Dipendenti dipendente = bl.RecuperaDipendente();

                bl.ScriviSuFile(dipendente, spese2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
