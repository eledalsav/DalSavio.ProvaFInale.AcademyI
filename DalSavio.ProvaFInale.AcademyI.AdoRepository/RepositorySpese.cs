using DalSavio.ProvaFInale.AcademyI.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalSavio.ProvaFInale.AcademyI.AdoRepository
{
    public class RepositorySpese : IRepositorySpese
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                         "Integrated Security = true";
        
        public void Update(Spese item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "update dbo.Spese set Spesa = @spesa, Approvata=@approvata, Approvatore=@approvatore where Id = @id";

                    command.Parameters.AddWithValue("@spesa", item.Spesa);
                    command.Parameters.AddWithValue("@approvata", item.Approvata);
                    if (item.Approvatore != null) {
                        command.Parameters.AddWithValue("@approvatore", (int?)item.Approvatore);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@approvatore", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Spese> Fetch()
        {
            try
            {
                List<Spese> spese = new List<Spese>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Spese";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Spese spesaa = new Spese();
                        spesaa.Spesa = (double)reader["Spesa"];
                        spesaa.Data = Convert.ToDateTime(reader["Data"]);
                        spesaa.Descrizione = (string)reader["Descrizione"];
                        spesaa.Dipendente = (int)reader["Dipendente"];
                        spesaa.Categorie = (EnumCategorie)reader["Categoria"];
                        spesaa.Id = (int)reader["Id"];


                        spese.Add(spesaa);
                    }
                }
                return spese;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByNome(string nome)
        {

        }
    }
}

 
