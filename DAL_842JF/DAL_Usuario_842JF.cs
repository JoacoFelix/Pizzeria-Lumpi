using System.Net;
using Microsoft.Data.SqlClient;
using Servicios_842JF;
using Servicios_842JF.Composite;

namespace DAL_842JF
{
    public class DAL_Usuario_842JF: IDAL_842JF
    {
        public void Guardar_842JF(Usuario_842JF usuario)
        {
            using(SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Usuario_842JF (DNI_842JF,nombre_842JF,apellido_842JF,login_842JF,contraseña_842JF,rol_842JF,mail_842JF,bloqueo_842JF,activo_842JF,contador_842JF,ultimoIntento_842JF,idioma_842JF)
                                    VALUES (@DNI_842JF,@nombre_842JF,@apellido_842JF,@login_842JF,@contraseña_842JF,@rol_842JF,@mail_842JF,@bloqueo_842JF,@activo_842JF,@contador_842JF,@ultimoIntento_842JF,@idioma_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", usuario.nombre_842JF);
                cmd.Parameters.AddWithValue("@apellido_842JF", usuario.apellido_842JF);
                cmd.Parameters.AddWithValue("@login_842JF", usuario.login_842JF);
                cmd.Parameters.AddWithValue("@contraseña_842JF", usuario.contraseña_842JF);
                cmd.Parameters.AddWithValue("@rol_842JF", usuario.rol_842JF.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", usuario.mail_842JF);
                cmd.Parameters.AddWithValue("@bloqueo_842JF", usuario.bloqueo_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", usuario.activo_842JF);
                cmd.Parameters.AddWithValue("@contador_842JF", usuario.contador_842JF);
                cmd.Parameters.AddWithValue("@ultimoIntento_842JF", usuario.ultimoIntento_842JF);
                cmd.Parameters.AddWithValue("@idioma_842JF", usuario.idioma_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Modificar_842JF(Usuario_842JF usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Usuario_842JF 
                                    SET nombre_842JF = @nombre_842JF,
                                        apellido_842JF = @apellido_842JF,
                                        login_842JF = @login_842JF,
                                        contraseña_842JF = @contraseña_842JF,
                                        rol_842JF = @rol_842JF,
                                        mail_842JF = @mail_842JF,
                                        bloqueo_842JF = @bloqueo_842JF,
                                        activo_842JF = @activo_842JF,
                                        contador_842JF = @contador_842JF,
                                        ultimoIntento_842JF = @ultimoIntento_842JF,
                                        idioma_842JF = @idioma_842JF
                                        WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre_842JF", usuario.nombre_842JF);
                cmd.Parameters.AddWithValue("@apellido_842JF", usuario.apellido_842JF);
                cmd.Parameters.AddWithValue("@login_842JF", usuario.login_842JF);
                cmd.Parameters.AddWithValue("@contraseña_842JF", usuario.contraseña_842JF);
                cmd.Parameters.AddWithValue("@rol_842JF", usuario.rol_842JF.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", usuario.mail_842JF);
                cmd.Parameters.AddWithValue("@bloqueo_842JF", usuario.bloqueo_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", usuario.activo_842JF);
                cmd.Parameters.AddWithValue("@contador_842JF", usuario.contador_842JF);
                cmd.Parameters.AddWithValue("@ultimoIntento_842JF", usuario.ultimoIntento_842JF);
                cmd.Parameters.AddWithValue("@idioma_842JF", usuario.idioma_842JF);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Desactivar_842JF(Usuario_842JF usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Usuario_842JF 
                                    SET activo_842JF = 0 
                                    WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Activar_842JF(Usuario_842JF usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Usuario_842JF 
                                    SET activo_842JF = 1 
                                    WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Desbloquear_842JF(Usuario_842JF usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Usuario_842JF 
                                    SET bloqueo_842JF = @bloqueo_842JF,
                                        contador_842JF = @contador_842JF,
                                        contraseña_842JF = @contraseña_842JF
                                    WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);
                cmd.Parameters.AddWithValue("@bloqueo_842JF", usuario.bloqueo_842JF);
                cmd.Parameters.AddWithValue("@contador_842JF", usuario.contador_842JF);
                cmd.Parameters.AddWithValue("@contraseña_842JF", usuario.contraseña_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Bloquear_842JF(Usuario_842JF usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Usuario_842JF 
                                    SET bloqueo_842JF = 1 
                                    WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", usuario.DNI_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Usuario_842JF> ObtenerTodos_842JF()
        {
            List<Usuario_842JF> lista = new List<Usuario_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Usuario_842JF user = new Usuario_842JF(reader["DNI_842JF"].ToString(), reader["nombre_842JF"].ToString(), reader["apellido_842JF"].ToString(), reader["login_842JF"].ToString(),
                        reader["contraseña_842JF"].ToString(), new Familia_842JF(Convert.ToInt32(reader["rol_842JF"])), reader["mail_842JF"].ToString(), Convert.ToBoolean(reader["bloqueo_842JF"]),
                        Convert.ToBoolean(reader["activo_842JF"].ToString()), Convert.ToInt32(reader["contador_842JF"]), Convert.ToDateTime(reader["ultimoIntento_842JF"]), reader["idioma_842JF"].ToString());

                    lista.Add(user);
                }
            }
            return lista;
        }
    }
}
