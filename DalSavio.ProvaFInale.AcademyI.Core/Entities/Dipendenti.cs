using System;

namespace DalSavio.ProvaFInale.AcademyI.Core
{
    public class Dipendenti
    {
        public string Nome { get; set; }
        public int? Id { get; set; }

        public Dipendenti()
        {

        }
        public Dipendenti(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }
    }
}
