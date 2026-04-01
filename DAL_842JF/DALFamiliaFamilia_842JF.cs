
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALFamiliaFamilia_842JF : IDAL_842JF
    {
        
        public void GuardarFamiliaFamilia_842JF(Perfil_842JF familia, Perfil_842JF famrela)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO FamiliaFamilia_842JF (codFamilia_842JF, codFamiliaRelacionado_842JF)
                                    VALUES (@codFamilia_842JF,@codFamiliaRelacionado_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codFamiliaRelacionado_842JF", famrela.codPerfil_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodosFamiliaFamilia_842JF(Perfil_842JF familia)
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT f.codFamilia_842JF, f.nombre_842JF, f.descripcion_842JF FROM Familia_842JF f 
                                                          INNER JOIN FamiliaFamilia_842JF ff ON f.codFamilia_842JF = ff.codFamiliaRelacionado_842JF
                                                          WHERE ff.codFamilia_842JF = @codFamilia", con);
                cmd.Parameters.AddWithValue("@codFamilia", familia.codPerfil_842JF);
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
        public void EliminarTodosFamiliaFamilia_842JF(Perfil_842JF familia)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = @"DELETE FROM FamiliaFamilia_842JF 
                            WHERE codFamilia_842JF = @cod";
                cmd.Parameters.AddWithValue("@cod", familia.codPerfil_842JF);
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"DELETE FROM FamiliaFamilia_842JF 
                            WHERE codFamiliaRelacionado_842JF = @cod";
                cmd.ExecuteNonQuery();

            }
        }
        public void EliminarFamiliaFamilia_842JF(Perfil_842JF fam, Perfil_842JF hijo)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM FamiliaFamilia_842JF 
                            WHERE codFamilia_842JF = @codFamilia_842JF AND codFamiliaRelacionado_842JF = @codFamiliaRelacionado_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", fam.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@codFamiliaRelacionado_842JF", hijo.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
