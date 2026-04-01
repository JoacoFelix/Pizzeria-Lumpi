using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{
    public class DALRecepcion_842JF : IDAL_842JF
    {
        public void Guardar_842JF(BERecepcion_842JF recepcion)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Recepcion_842JF (codProducto_842JF, CUIT_842JF, cantidad_842JF, fecha_842JF,descripcion_842JF)
                                    VALUES (@codProducto_842JF,@CUIT_842JF,@cantidad_842JF,@fecha_842JF,@descripcion_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", recepcion.producto_842JF.codProducto_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", recepcion.proveedor_842JF.CUIT_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", recepcion.cantidad_842JF);
                cmd.Parameters.AddWithValue("@fecha_842JF", recepcion.fecha_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", recepcion.descripcion_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BERecepcion_842JF> ObtenerTodos_842JF()
        {
            List<BERecepcion_842JF> lista = new List<BERecepcion_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Recepcion_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BERecepcion_842JF recepcion = new BERecepcion_842JF(Convert.ToInt32(reader["codRecepcion_842JF"]), new BEProducto_842JF(Convert.ToInt32(reader["codProducto_842JF"])),
                                                                   new BEProveedor_842JF(reader["CUIT_842JF"].ToString()), Convert.ToInt32(reader["cantidad_842JF"]), Convert.ToDateTime(reader["fecha_842JF"]),
                                                                   reader["descripcion_842JF"].ToString());

                    lista.Add(recepcion);
                }
            }
            return lista;
        }
    }
}
