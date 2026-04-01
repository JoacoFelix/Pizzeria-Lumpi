
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALPermisoFamilia_842JF : IDAL_842JF
    {
        
        public void GuardarPermisoFamilia_842JF(Perfil_842JF familia,Perfil_842JF permiso)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO PermisoFamilia_842JF (codPermiso_842JF, codFamilia_842JF)
                                    VALUES (@codPermiso_842JF,@codFamilia_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPermiso_842JF", permiso.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodos_842JF(Perfil_842JF familia)
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT p.codPermiso_842JF, p.nombre_842JF, p.descripcion_842JF FROM Permiso_842JF p 
                                                          INNER JOIN PermisoFamilia_842JF fp ON p.codPermiso_842JF = fp.codPermiso_842JF 
                                                          WHERE fp.codFamilia_842JF = @codFamilia", con);
                cmd.Parameters.AddWithValue("@codFamilia", familia.codPerfil_842JF);
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
        public void EliminarTodosPermisoFamilia_842JF(Perfil_842JF familia)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM PermisoFamilia_842JF 
                            WHERE codFamilia_842JF = @codFamilia_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarPermisoFamilia_842JF(Perfil_842JF fam, Perfil_842JF hijo)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM PermisoFamilia_842JF 
                            WHERE codFamilia_842JF = @codFamilia_842JF AND codPermiso_842JF = @codPermiso_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", fam.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codPermiso_842JF", hijo.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
