using DalSavio.ProvaFInale.AcademyI.AdoRepository;
using DalSavio.ProvaFInale.AcademyI.Core;
using System;

namespace DalSavio.ProvaFInale.AcademyI.ConsoleDipendente
{

    private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryDipendenti(), new RepositorySpese());
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto! Inserisci il tuo nome:");
        }
    }
}
