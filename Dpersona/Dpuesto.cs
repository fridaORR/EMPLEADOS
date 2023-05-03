using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDper
{
   public class Dpuesto
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);


        public DataTable Obtener()
        {
            string query = "Select * from puesto";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta;
        }
        public DataRow ObtenerId(int id)
        {
            string query = $"select * from puesto where id={id}";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta.Rows[0];

        }
        public int Agregar(string nombre)
        {

            string query = $"insert into puesto values ('{nombre}')";
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                int filaAfectada = com.ExecuteNonQuery();
                con.Close();
                return filaAfectada;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public int Editar(string nombre, int id)
        {
            string query = $"Update puesto set nombre='{nombre}' where= id={id}";
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                int filaAfectada = com.ExecuteNonQuery();
                con.Close();
                return filaAfectada;

            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public int Eliminar(int id)
        {
            string query = $"Delete puesto where id={id}";
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                int filaAfecta = com.ExecuteNonQuery();
                con.Close();
                return filaAfecta;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
    }
}
 