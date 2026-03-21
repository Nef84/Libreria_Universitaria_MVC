using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Universitaria.AccesoDatos
{
    public class LibroDB
    {
        private string cadena = ConfigurationManager
                                    .ConnectionStrings["LibreriaDB"].ConnectionString;

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"SELECT l.LibroID, l.Titulo, l.Autor,
                                      l.Precio, l.Stock,
                                      c.Nombre AS Categoria
                               FROM Libros l
                               INNER JOIN Categorias c
                                       ON l.CategoriaID = c.CategoriaID
                               ORDER BY l.Titulo";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable Buscar(string titulo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"SELECT l.LibroID, l.Titulo, l.Autor,
                                      l.Precio, l.Stock,
                                      c.Nombre AS Categoria
                               FROM Libros l
                               INNER JOIN Categorias c
                                       ON l.CategoriaID = c.CategoriaID
                               WHERE l.Titulo LIKE @Titulo
                               ORDER BY l.Titulo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", "%" + titulo + "%");
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public DataRow ObtenerPorID(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "SELECT * FROM Libros WHERE LibroID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public void Insertar(string titulo, string autor,
                             decimal precio, int stock, int categoriaID)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"INSERT INTO Libros (Titulo, Autor, Precio, Stock, CategoriaID)
                               VALUES (@Titulo, @Autor, @Precio, @Stock, @CategoriaID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(int id, string titulo, string autor,
                               decimal precio, int stock, int categoriaID)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"UPDATE Libros
                               SET Titulo      = @Titulo,
                                   Autor       = @Autor,
                                   Precio      = @Precio,
                                   Stock       = @Stock,
                                   CategoriaID = @CategoriaID
                               WHERE LibroID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "DELETE FROM Libros WHERE LibroID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}