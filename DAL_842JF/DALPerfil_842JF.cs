
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALPerfil_842JF : IDAL_842JF
    {
       
        public void GuardarPerfil_842JF(Perfil_842JF componente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Perfil_842JF (codPerfil_842JF,nombre_842JF,descripcion_842JF)
                                    VALUES (@codPerfil_842JF,@nombre_842JF,@descripcion_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", componente.codPerfil_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", componente.nombre_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", componente.descripcion_842JF);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Perfil_842JF> ObtenerTodos_842JF()
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Perfil_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Perfil_842JF perf = new Familia_842JF(Convert.ToInt32(reader["codPerfil_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString());

                    lista.Add(perf);
                }
            }
            return lista;
        }
        public void EliminarPerfil_842JF(Perfil_842JF perfil)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM Perfil_842JF 
                            WHERE codPerfil_842JF = @codPerfil_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codPerfil_842JF", perfil.codPerfil_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
