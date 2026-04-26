using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Data
{
    public class LibroDatos
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["LibreriaDB"].ConnectionString;

        public List<Libro> Listar()
        {
            var lista = new List<Libro>();

            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"SELECT l.LibroID, l.Titulo, l.Autor, l.Precio, l.Stock,
                                      l.CategoriaID, c.Nombre AS Categoria
                               FROM Libros l
                               INNER JOIN Categorias c ON l.CategoriaID = c.CategoriaID
                               ORDER BY l.Titulo";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Libro
                        {
                            LibroId = (int)dr["LibroID"],
                            Titulo = dr["Titulo"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            Precio = (decimal)dr["Precio"],
                            Stock = (int)dr["Stock"],
                            CategoriaId = (int)dr["CategoriaID"],
                            NombreCategoria = dr["Categoria"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Libro ObtenerPorId(int id)
        {
            Libro libro = null;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"SELECT l.LibroID, l.Titulo, l.Autor, l.Precio, l.Stock,
                                      l.CategoriaID, c.Nombre AS Categoria
                               FROM Libros l
                               INNER JOIN Categorias c ON l.CategoriaID = c.CategoriaID
                               WHERE l.LibroID = @LibroID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@LibroID", id);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        libro = new Libro
                        {
                            LibroId = (int)dr["LibroID"],
                            Titulo = dr["Titulo"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            Precio = (decimal)dr["Precio"],
                            Stock = (int)dr["Stock"],
                            CategoriaId = (int)dr["CategoriaID"],
                            NombreCategoria = dr["Categoria"].ToString()
                        };
                    }
                }
            }

            return libro;
        }

        public void Insertar(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"INSERT INTO Libros (Titulo, Autor, Precio, Stock, CategoriaID)
                               VALUES (@Titulo, @Autor, @Precio, @Stock, @CategoriaID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                cmd.Parameters.AddWithValue("@Precio", libro.Precio);
                cmd.Parameters.AddWithValue("@Stock", libro.Stock);
                cmd.Parameters.AddWithValue("@CategoriaID", libro.CategoriaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"UPDATE Libros
                               SET Titulo = @Titulo,
                                   Autor = @Autor,
                                   Precio = @Precio,
                                   Stock = @Stock,
                                   CategoriaID = @CategoriaID
                               WHERE LibroID = @LibroID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@LibroID", libro.LibroId);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                cmd.Parameters.AddWithValue("@Precio", libro.Precio);
                cmd.Parameters.AddWithValue("@Stock", libro.Stock);
                cmd.Parameters.AddWithValue("@CategoriaID", libro.CategoriaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = "DELETE FROM Libros WHERE LibroID = @LibroID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@LibroID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
