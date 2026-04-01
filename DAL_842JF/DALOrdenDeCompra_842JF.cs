using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;

using Servicios_842JF;

namespace DAL_842JF
{
    public class DALOrdenDeCompra_842JF : IDAL_842JF
    {
        public void Guardar_842JF(BEOrdenCompra_842JF orden)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO OrdenDeCompra_842JF (fecha_842JF,codProducto_842JF,CUIT_842JF,precioUnitario_842JF,cantidad_842JF,recibida_842JF,pago_842JF)
                                    VALUES (@fecha_842JF,@codProducto_842JF,@CUIT_842JF,@precioUnitario_842JF,@cantidad_842JF,@recibida_842JF,@pago_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@fecha_842JF", orden.fecha_842JF);
                cmd.Parameters.AddWithValue("@codProducto_842JF", orden.producto_842JF.codProducto_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", orden.proveedor_842JF.CUIT_842JF);
                cmd.Parameters.AddWithValue("@precioUnitario_842JF", orden.precioUnitario_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", orden.cantidad_842JF);
                cmd.Parameters.AddWithValue("@recibida_842JF", orden.recibida_842JF);
                cmd.Parameters.AddWithValue("@pago_842JF", orden.pago_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEOrdenCompra_842JF> ObtenerTodos_842JF()
        {
            List<BEOrdenCompra_842JF> lista = new List<BEOrdenCompra_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrdenDeCompra_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEOrdenCompra_842JF orden = new BEOrdenCompra_842JF(Convert.ToInt32(reader["codOrdenCompra_842JF"]), Convert.ToDateTime(reader["fecha_842JF"]),
                                                                  new BEProducto_842JF(Convert.ToInt32(reader["codProducto_842JF"])), new BEProveedor_842JF(reader["CUIT_842JF"].ToString()),
                                                                  Convert.ToDecimal(reader["precioUnitario_842JF"]), Convert.ToInt32(reader["cantidad_842JF"]), Convert.ToBoolean(reader["recibida_842JF"]), Convert.ToBoolean(reader["pago_842JF"]));

                    lista.Add(orden);
                }
            }
            return lista;
        }
        public void Recibir_842JF(BEOrdenCompra_842JF orden)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE OrdenDeCompra_842JF 
                                    SET recibida_842JF = @recibida_842JF
                                        WHERE codOrdenCompra_842JF = @codOrdenCompra_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@recibida_842JF", orden.recibida_842JF);
                cmd.Parameters.AddWithValue("@codOrdenCompra_842JF", orden.codOrdenCompra_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Pagar_842JF(BEOrdenCompra_842JF orden)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE OrdenDeCompra_842JF 
                                    SET pago_842JF = @pago_842JF
                                        WHERE codOrdenCompra_842JF = @codOrdenCompra_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@pago_842JF", orden.pago_842JF);
                cmd.Parameters.AddWithValue("@codOrdenCompra_842JF", orden.codOrdenCompra_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarOrden_842JF(BEOrdenCompra_842JF orden)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM OrdenDeCompra_842JF 
                            WHERE codOrdenCompra_842JF = @codOrdenCompra_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codOrdenCompra_842JF", orden.codOrdenCompra_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
