using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSavio.ProvaFInale.AcademyI.Core
{
    public class BusinessLayer:IBusinessLayer
    {
        
        private readonly IRepositoryDipendenti IRepositoryDipendenti;
        private readonly IRepositorySpese IRepositorySpese;

        public BusinessLayer(IRepositoryDipendenti iRepositoryDipendenti, IRepositorySpese iRepositorySpese)
        {
            IRepositoryDipendenti = iRepositoryDipendenti;
            IRepositorySpese =iRepositorySpese;
        }

        public List<Spese> ScegliApprovatore()
        {
            //List<Dipendenti> dipendenti = new List<Dipendenti>();
            List<Spese> spese = new List<Spese>();
            try
            {
                spese = IRepositorySpese.Fetch();
                if (spese.Count > 0)
                {
                    foreach(var spesa in spese)
                    {
                        if(spesa.Spesa>0 && spesa.Spesa < 400 && spesa.SottopostaApprovazione==false)
                        {
                            spesa.Approvatore = EnumApprovatori.Manager;
                            spesa.Approvata = true;
                            spesa.SottopostaApprovazione = true;
                        }
                        else if (spesa.Spesa > 400 && spesa.Spesa <= 1000 && spesa.SottopostaApprovazione == false)
                        {
                            spesa.Approvatore = EnumApprovatori.OperationManager;
                            spesa.Approvata = true;
                            spesa.SottopostaApprovazione = true;
                        }
                        else if (spesa.Spesa > 1000 && spesa.Spesa <= 2500 && spesa.SottopostaApprovazione == false)
                        {
                            spesa.Approvatore = EnumApprovatori.CEO;
                            spesa.Approvata = true;
                            spesa.SottopostaApprovazione = true;
                        }
                        else if(spesa.Spesa >2500 && spesa.SottopostaApprovazione == false)
                        {
                            spesa.Approvata = false;
                            spesa.SottopostaApprovazione = true;
                        }
                        IRepositorySpese.Update(spesa);
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return spese;
        }

        public List<Spese> CalcolaRimborso(List<Spese> spese)
        {
           try
            {
                //spese = IRepositorySpese.Fetch();
                if (spese.Count > 0)
                {
                    foreach (var spesa in spese)
                    {
                        if (spesa.Approvata == false)
                        {
                            spesa.Rimborso = 0;
                        }
                        else
                        {
                            if ((int)spesa.Categorie == 1)
                            {
                                spesa.Rimborso = spesa.Spesa / 100 * 70;
                            }
                            else if ((int)spesa.Categorie == 2)
                            {
                                spesa.Rimborso = spesa.Spesa;
                            }
                            else if ((int)spesa.Categorie == 3)
                            {
                                spesa.Rimborso = spesa.Spesa / 2 + 50;
                            }
                            else if ((int)spesa.Categorie == 4)
                            {
                                spesa.Rimborso = spesa.Spesa / 10;
                            }
                        }
                    }
                }
                //return spese;
            }catch(Exception ex)
            {
                throw ex;
            }
            return spese;
        }
        public void ScriviSuFile(Dipendenti dipendente, List<Spese> spese)
        {
            string path = @"C:\Users\elena.dal.savio\Desktop\RiepilogoSpeseDipendente.txt";
            //List<Spese> spese = new List<Spese>();
            try
            {
                //spese = IRepositorySpese.Fetch();
                foreach (var spesa in spese)
                {
                    if (spesa.Dipendente==dipendente.Id&& spesa.SottopostaApprovazione==true) {
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            string approvata;
                            if (spesa.Approvata == true)
                            {
                                approvata = "sì";
                            }
                            else
                            {
                                approvata = "no";
                            }
                            sw.WriteLine($"{spesa.Data}, {spesa.Categorie} " +
                                $"- Spesa Sostenuta : {spesa.Spesa}€ - Spesa approvata:"+approvata+$"-Rimborso:{spesa.Rimborso}€");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dipendenti RecuperaDipendente()
        {
            Dipendenti dipendente = new Dipendenti();
            do
            {
                string choice;
                do
                {
                    Console.WriteLine("Benvenuto!\nInserisci il tuo Nome");
                    choice = Console.ReadLine();
                } while (string.IsNullOrEmpty(choice));
                dipendente = GetByNome(choice);
            } while (dipendente==null);
            return dipendente;
           
        }
        public Dipendenti? GetByNome(string nome)
        {
            List<Dipendenti> dipendenti = IRepositoryDipendenti.Fetch();
            return dipendenti.Find(d => d.Nome == nome);
            //foreach(var d in dipendenti)
            //{
            //    if (d.Nome == nome)
            //    {
            //        return d;
            //    }
            //    return null;
            //}
        }
    }
}

