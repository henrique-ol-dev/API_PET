using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Contexts
{
    public class ClinicaContext
    {
        SqlConnection con = new SqlConnection();

        public ClinicaContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-RAOH29V;Initial Catalog=boletim;Integrated Security=True";
        }


        public SqlConnection Connect()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
