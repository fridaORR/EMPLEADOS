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
    public class Dempleados
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);


        public DataTable Obtener()
        {
   string query = "select ep.id,per.nombre,per.apellido,per.fechaNacimiento,p.nombre as puesto,p.id as idpuesto,per.id as idpersona from EmpleadoPuesto ep inner join Puesto p on  ep.puesto=p.id inner join Persona per on ep.persona=per.id";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta;
        }
        public DataRow ObtenerId(int id)
        {
            string query = $"select ep.id,per.nombre,per.apellido,per.fechaNacimiento,p.nombre as puesto ,p.id as idpuesto,per.id as idpersona from EmpleadoPuesto ep inner join Puesto p on  ep.puesto=p.id inner join Persona per on ep.persona=per.id  where ep.id={id}";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ta = new DataTable();
            da.Fill(ta);
            return ta.Rows[0];

        }
        public int Agregar(int puesto,int persona)
        {

            string query = $"insert into EmpleadoPuesto values ({puesto},{persona})";
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
        public int Editar(int persona, int puesto ,int empleados)
        {
            string query = $"Update EmpleadoPuesto set persona={persona},puesto={puesto} where= id={empleados}";
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
            string query = $"Delete EmpleadoPuesto where id={id}";
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