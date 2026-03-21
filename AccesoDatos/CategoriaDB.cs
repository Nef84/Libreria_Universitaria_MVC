using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Universitaria.AccesoDatos
{
    public class CategoriaDB
    {
        private string cadena = ConfigurationManager
                                    .ConnectionStrings["LibreriaDB"].ConnectionString;

        public DataTable ObtenerTodas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "SELECT CategoriaID, Nombre, Descripcion " +
                             "FROM Categorias ORDER BY Nombre";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        public void Insertar(string nombre, string descripcion)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "INSERT INTO Categorias (Nombre, Descripcion) " +
                             "VALUES (@Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(int id, string nombre, string descripcion)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "UPDATE Categorias " +
                             "SET Nombre = @Nombre, Descripcion = @Descripcion " +
                             "WHERE CategoriaID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "DELETE FROM Categorias WHERE CategoriaID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    } 
}