using DalSavio.ProvaFInale.AcademyI.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSavio.ProvaFInale.AcademyI.AdoRepository
{
    public class RepositoryDipendenti : IRepositoryDipendenti
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                         "Integrated Security = true";

        public List<Dipendenti> Fetch()
        {
            try
            {
                List<Dipendenti> dipendenti = new List<Dipendenti>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Dipendenti";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];
                        var id = (int)reader["Id"];

                        Dipendenti dipendente = new Dipendenti(nome, id);

                        dipendenti.Add(dipendente);
                    }
                }
                return dipendenti;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Dipendenti item)
        {
            throw new NotImplementedException();
        }

        //public Dipendenti GetByNome(string nome)
        //{
        //    List<Dipendenti> dipendenti=

    }
}

