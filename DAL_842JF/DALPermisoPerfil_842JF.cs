
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALPermisoPerfil_842JF : IDAL_842JF
    {
        
        public void GuardarPermisoPerfil_842JF(Perfil_842JF familia, Perfil_842JF permiso)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO PermisoPerfil_842JF (codPermiso_842JF, codPerfil_842JF)
                                    VALUES (@codPermiso_842JF,@codPerfil_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPermiso_842JF", permiso.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", familia.codPerfil_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodos_842JF(Perfil_842JF perfil)
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT p.codPermiso_842JF, p.nombre_842JF, p.descripcion_842JF FROM Permiso_842JF p 
                                                          INNER JOIN PermisoPerfil_842JF fp ON p.codPermiso_842JF = fp.codPermiso_842JF 
                                                          WHERE fp.codPerfil_842JF = @codPerfil", con);
                cmd.Parameters.AddWithValue("@codPerfil", perfil.codPerfil_842JF);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Perfil_842JF perm = new Permiso_842JF(Convert.ToInt32(reader["codPermiso_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString());

                    lista.Add(perm);
                }
            }
            return lista;
        }
        public void EliminarTodosPermisoPerfil_842JF(Perfil_842JF perf)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM PermisoPerfil_842JF 
                            WHERE codPerfil_842JF = @codPerfil_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perf.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarPermisoPerfil_842JF(Perfil_842JF perf,Perfil_842JF hijo)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM PermisoPerfil_842JF 
                            WHERE codPerfil_842JF = @codPerfil_842JF AND codPermiso_842JF = @codPermiso_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perf.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codPermiso_842JF", hijo.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
