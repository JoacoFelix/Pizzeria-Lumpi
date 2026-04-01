using BE_842JF;
using Servicios_842JF;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALCliente_842JF : IDAL_842JF
    {
        
        public BECliente_842JF BuscarCliente_842JF(BECliente_842JF cliente)
        {
            BECliente_842JF clienteEncontrado = null;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = "SELECT * FROM Cliente_842JF WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", cliente.DNI_842JF);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    clienteEncontrado = new BECliente_842JF(
                        reader["DNI_842JF"].ToString(),
                        reader["nombre_842JF"].ToString(),
                        reader["apellido_842JF"].ToString(),
                        reader["mail_842JF"].ToString(),
                        Convert.ToInt32(reader["telefono_842JF"]),
                        Convert.ToBoolean(reader["activo_842JF"])
                    );
                }
            }

            return clienteEncontrado;
        }
        public List <BECliente_842JF> ObtenerTodos_842JF()
        {
            List<BECliente_842JF> lista = new List<BECliente_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BECliente_842JF cliente = new BECliente_842JF(reader["DNI_842JF"].ToString(), reader["nombre_842JF"].ToString(), 
                                                                  reader["apellido_842JF"].ToString(),reader["mail_842JF"].ToString(),
                                                                  Convert.ToInt32(reader["telefono_842JF"]), Convert.ToBoolean(reader["activo_842JF"]));

                    lista.Add(cliente);
                }
            }
            return lista;
        }
        public void RegistrarCliente_842JF(BECliente_842JF cliente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Cliente_842JF (DNI_842JF,nombre_842JF,apellido_842JF,mail_842JF,telefono_842JF,activo_842JF)
                                    VALUES (@DNI_842JF,@nombre_842JF,@apellido_842JF,@mail_842JF,@telefono_842JF,@activo_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", cliente.DNI_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", cliente.nombre_842JF);
                cmd.Parameters.AddWithValue("@apellido_842JF", cliente.apellido_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", cliente.mail_842JF);
                cmd.Parameters.AddWithValue("@telefono_842JF", cliente.telefono_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", cliente.activo_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Modificar_842JF(BECliente_842JF cliente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Cliente_842JF 
                                    SET nombre_842JF = @nombre_842JF,
                                        apellido_842JF = @apellido_842JF,
                                        mail_842JF = @mail_842JF,
                                        telefono_842JF = @telefono_842JF,
                                        activo_842JF = @activo_842JF
                                        WHERE DNI_842JF = @DNI_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre_842JF", cliente.nombre_842JF);
                cmd.Parameters.AddWithValue("@apellido_842JF", cliente.apellido_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", cliente.mail_842JF);
                cmd.Parameters.AddWithValue("@telefono_842JF", cliente.telefono_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", cliente.activo_842JF);
                cmd.Parameters.AddWithValue("@DNI_842JF", cliente.DNI_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
