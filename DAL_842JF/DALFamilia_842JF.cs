using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Servicios_842JF;
using Servicios_842JF.Composite;

namespace DAL_842JF
{
    public class DALFamilia_842JF : IDAL_842JF
    {
        
        public void GuardarFamilia_842JF(Perfil_842JF componente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Familia_842JF (codFamilia_842JF,nombre_842JF,descripcion_842JF)
                                    VALUES (@codFamilia_842JF,@nombre_842JF,@descripcion_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", componente.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", componente.nombre_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", componente.descripcion_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodas_842JF()
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Familia_842JF", con);
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
        public void EliminarFamilia_842JF(Perfil_842JF familia)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM Familia_842JF 
                            WHERE codFamilia_842JF = @codFamilia_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codFamilia_842JF", familia.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

