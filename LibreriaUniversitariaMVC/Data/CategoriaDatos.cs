using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Data
{
    public class CategoriaDatos
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["LibreriaDB"].ConnectionString;

        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();

            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "SELECT CategoriaID, Nombre, Descripcion FROM Categorias ORDER BY Nombre";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            CategoriaId = (int)dr["CategoriaID"],
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"] == System.DBNull.Value ? string.Empty : dr["Descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Categoria ObtenerPorId(int id)
        {
            Categoria categoria = null;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "SELECT CategoriaID, Nombre, Descripcion FROM Categorias WHERE CategoriaID = @CategoriaID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CategoriaID", id);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        categoria = new Categoria
                        {
                            CategoriaId = (int)dr["CategoriaID"],
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"] == System.DBNull.Value ? string.Empty : dr["Descripcion"].ToString()
                        };
                    }
                }
            }

            return categoria;
        }

        public void Insertar(Categoria categoria)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(categoria.Descripcion) ? (object)System.DBNull.Value : categoria.Descripcion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Categoria categoria)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE CategoriaID = @CategoriaID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaId);
                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(categoria.Descripcion) ? (object)System.DBNull.Value : categoria.Descripcion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "DELETE FROM Categorias WHERE CategoriaID = @CategoriaID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CategoriaID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
