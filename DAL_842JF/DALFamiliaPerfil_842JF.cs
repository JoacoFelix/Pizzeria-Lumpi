
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALFamiliaPerfil_842JF : IDAL_842JF
    {
       
        public void GuardarFamiliaPerfil_842JF(Perfil_842JF perfil, Perfil_842JF familia)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO FamiliaPerfil_842JF (codFamilia_842JF, codPerfil_842JF)
                                    VALUES (@codFamilia_842JF,@codPerfil_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perfil.codPerfil_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodosFamiliaPerfil_842JF(Perfil_842JF perfil)
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT f.codFamilia_842JF, f.nombre_842JF, f.descripcion_842JF FROM Familia_842JF f 
                                                          INNER JOIN FamiliaPerfil_842JF ff ON f.codFamilia_842JF = ff.codFamilia_842JF
                                                          WHERE ff.codPerfil_842JF = @codPerfil", con);
                cmd.Parameters.AddWithValue("@codPerfil", perfil.codPerfil_842JF);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Perfil_842JF fam = new Familia_842JF(Convert.ToInt32(reader["codFamilia_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString());

                    lista.Add(fam);
                }
            }
            return lista;
        }
        public void EliminarTodosFamilia_842JF(Perfil_842JF familia)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM FamiliaPerfil_842JF 
                            WHERE codFamilia_842JF = @codFamilia_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarTodosPerfil_842JF(Perfil_842JF perfil)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM FamiliaPerfil_842JF 
                            WHERE codPerfil_842JF = @codPerfil_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perfil.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarFamiliaPerfil_842JF(Perfil_842JF perf, Perfil_842JF hijo)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM FamiliaPerfil_842JF 
                            WHERE codPerfil_842JF = @codPerfil_842JF AND codFamilia_842JF = @codFamilia_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perf.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", hijo.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
