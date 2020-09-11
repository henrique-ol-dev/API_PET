using API_PetShop.Contexts;
using API_PetShop.Controllers;
using API_PetShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class TipoPetRepository : ITipoPet
    {

        ClinicaContext con = new ClinicaContext();
        SqlCommand cmd = new SqlCommand();

        public List<TipoPet> Create(TipoPet a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
                "INSERT INTO TipoPet(NomeTipoPet) " +
                "VALUES(@NomeTipoPet)"
                ;
            cmd.Parameters.AddWithValue("NomeTipoPet", a.NomeTipoPet);

            SqlDataReader data = cmd.ExecuteReader();


            con.Desconnect();
            return ReadAll();
        }

        public void Delete(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "DELETE FROM Tipo WHERE IdTipo= @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
        }

        public List<TipoPet> ReadAll()
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Tipo";

            SqlDataReader data = cmd.ExecuteReader();
            List<TipoPet> listaTipo = new List<TipoPet>();

            Listar(data, listaTipo);
            con.Desconnect();

            return listaTipo;
        }

        public TipoPet SearchForId(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Tipo WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader data = cmd.ExecuteReader();
            TipoPet tipo = new TipoPet();

            ReadEspecify(data, tipo);

            con.Desconnect();
            return tipo;
        }

        public List<TipoPet> Update(int id, TipoPet a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
               "UPDATE Tipo SET " +
               "NomeTipo = @NomeTipo " +
               "WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("NomeTipo", a.NomeTipoPet);

            SqlDataReader data = cmd.ExecuteReader();
            con.Desconnect();
            return ReadAll();

        }

        /// <summary>
        /// Lista todos os objetos
        /// </summary>
        /// <param name="data">SqlDataReader</param>
        /// <param name="listaTipoPet">A Lista que voce quer listar</param>

        public void Listar(SqlDataReader data, List<TipoPet> listaTipoPet)
        {
            while (data.Read())
            {
                listaTipoPet.Add(new TipoPet()
                {
                    IdTipoPet = Convert.ToInt32(data.GetValue(0)),
                    NomeTipoPet = Convert.ToString(data.GetValue(1))
                });
            }
        }
        /// <summary>
        /// Le um objeto especifico
        /// </summary>
        /// <param name="data">SqlDataReader</param>
        /// <param name="tipo">O Objeto que voce quer ler</param>
        public void ReadEspecify(SqlDataReader data, TipoPet tipo)
        {
            while (data.Read())
            {
                tipo.IdTipoPet = Convert.ToInt32(data.GetValue(0));
                tipo.NomeTipoPet = Convert.ToString(data.GetValue(1));
            }
        }



    }
}
