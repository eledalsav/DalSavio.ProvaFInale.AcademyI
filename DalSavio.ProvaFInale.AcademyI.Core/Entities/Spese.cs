using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSavio.ProvaFInale.AcademyI.Core
{
    public class Spese
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Spesa { get; set; }
        public EnumCategorie Categorie { get; set; }
        public string Descrizione { get; set; }
        public int Dipendente { get; set; }
        public bool SottopostaApprovazione = false;
        public bool? Approvata { get; set; }
        public double? Rimborso { get; set; }
        
        public EnumApprovatori? Approvatore { get; set; }

        public Spese()
        {

        }
        //public Spese(int id, DateTime data, double spesa, EnumCategorie categorie, string descrizione, int dipendente, bool? approvata, bool? rimborso, EnumApprovatori? approvatori)
        //{
        //    Id = id;
        //    Data = data;
        //    Categorie = categorie;
        //    Descrizione = descrizione;
        //    Dipendente = dipendente;
        //    Approvata = approvata;
        //    Rimborso = rimborso;
        //    Approvatori = approvatori;
        //}
    }
    public enum EnumApprovatori
    {
        Manager=1,
        OperationManager=2,
        CEO=3
    }
    public enum EnumCategorie
    {
        Vito=1,
        Alloggio=2,
        Trasferta=3,
        Altro=4
    }
}
