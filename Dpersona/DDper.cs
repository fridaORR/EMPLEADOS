using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDper

{
    public class DDpersona 
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);


        public DataTable Obtener()
        {
            string query = "Select * from persona";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta;
        }
        public DataRow ObtenerId(int id)
        {
            string query = $"select * from persona where id={id}";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta.Rows[0];

        }
        public int Agregar(string nombre, string apellido, DateTime fechaNacimiento)
        {

            string query = $"insert into persona values ('{nombre}','{apellido}','{fechaNacimiento}')";
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
        public int Editar(string nombre, string apellido, int id, DateTime fecha)
        {
            string query = $"Update persona set nombre ='{nombre}',apellido='{apellido}',fechaNacimiento='{fecha}' where id={id}";
           
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
            string query = $"Delete persona where id={id}";
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