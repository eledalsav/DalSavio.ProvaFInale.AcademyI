using DalSavio.ProvaFInale.AcademyI.Core;
using DalSavio.ProvaFInale.AcademyI.AdoRepository;
using System;
using System.Collections.Generic;

namespace DalSavio.ProvaFInale.AcademyI.ConsoleApp
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryDipendenti(), new RepositorySpese());

        static void Main(string[] args)
        {
            try
            {
                List<Spese> spese = bl.ScegliApprovatore();
                List<Spese> spese2 = bl.CalcolaRimborso(spese);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
