using API_PetShop.Contexts;
using API_PetShop.Domains;
using API_PetShop.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class RacaRepository : IRaca
    {
        ClinicaContext con = new ClinicaContext();
        SqlCommand cmd = new SqlCommand();
        public List<Raca> Create(Raca a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
                "INSERT INTO Raca(NomeRaca) " +
                "VALUES(@NomeRaca)"
                ;
            cmd.Parameters.AddWithValue("NomeRaca", a.NomeRaca);

            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
            return ReadAll();
        }

        public void Delete(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca= @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
        }

        public List<Raca> ReadAll()
        {
           cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader data = cmd.ExecuteReader();
            List<Raca> listaRaca = new List<Raca>();

            Listar(data, listaRaca);
            con.Desconnect();

            return listaRaca;
        }

        public Raca SearchForId(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader data = cmd.ExecuteReader();
            Raca raca = new Raca();

            ReadEspecify(data, raca);

            con.Desconnect();
            return raca;
        }

        public List<Raca> Update(int id, Raca a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
               "UPDATE Raca SET " +
               "NomeRaca = @NomeRaca " +
               "WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("NomeRaca", a.NomeRaca);

            SqlDataReader data = cmd.ExecuteReader();
            con.Desconnect();
            return ReadAll();
        }


    }
}
