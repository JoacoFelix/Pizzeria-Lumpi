using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{
    public class DALBitacoraEvento_842JF : IDAL_842JF
    {
        
        public List<BEEvento_842JF> ObtenerTodos_842JF()
        {
            List<BEEvento_842JF> lista = new List<BEEvento_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BitacoraEvento_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEEvento_842JF evento = new BEEvento_842JF(Convert.ToInt32(reader["idEvento_842JF"]), reader["login_842JF"].ToString(),
                                                                  Convert.ToDateTime(reader["fechaHora_842JF"]), reader["modulo_842JF"].ToString(),
                                                                  reader["evento_842JF"].ToString(), Convert.ToInt32(reader["criticidad_842JF"]));

                    lista.Add(evento);
                }
            }
            return lista;
        }
        public void RegistrarEvento_842JF(BEEvento_842JF evento)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO BitacoraEvento_842JF (idEvento_842JF,login_842JF,fechaHora_842JF,modulo_842JF,evento_842JF,criticidad_842JF)
                                    VALUES (@idEvento_842JF,@login_842JF,@fechaHora_842JF,@modulo_842JF,@evento_842JF,@criticidad_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idEvento_842JF", evento.idEvento_842JF);
                cmd.Parameters.AddWithValue("@login_842JF", evento.login_842JF);
                cmd.Parameters.AddWithValue("@fechaHora_842JF", evento.fechaHora_842JF);
                cmd.Parameters.AddWithValue("@modulo_842JF", evento.modulo_842JF);
                cmd.Parameters.AddWithValue("@evento_842JF", evento.evento_842JF);
                cmd.Parameters.AddWithValue("@criticidad_842JF", evento.criticidad_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
