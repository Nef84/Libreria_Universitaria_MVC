using System.Configuration;
using System.Data.SqlClient;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Data
{
    public class UsuarioDatos
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["LibreriaDB"].ConnectionString;

        public UsuarioSesion ValidarUsuario(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                return null;
            }

            UsuarioSesion usuario = null;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"SELECT u.UsuarioID, u.NombreUsuario, u.Nombre, r.Nombre AS Rol
                               FROM Usuarios u
                               INNER JOIN Roles r ON u.RolID = r.RolID
                               WHERE u.NombreUsuario = @NombreUsuario
                                 AND u.Contrasena = @Contrasena
                                 AND u.Activo = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario.Trim());
                cmd.Parameters.AddWithValue("@Contrasena", contrasena.Trim());
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuario = new UsuarioSesion
                        {
                            UsuarioId = (int)dr["UsuarioID"],
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Rol = dr["Rol"].ToString()
                        };
                    }
                }
            }

            return usuario;
        }
    }
}
