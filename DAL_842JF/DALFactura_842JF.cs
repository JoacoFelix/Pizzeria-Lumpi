using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{
    public class DALFactura_842JF : IDAL_842JF
    {
        
        public void CrearFactura_842JF(BEFactura_842JF factura)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Factura_842JF (fecha_842JF,medioDePago_842JF,nroPedido_842JF)
                                    VALUES (@fecha_842JF,@medioDePago_842JF,@nroPedido_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@fecha_842JF", factura.fecha_842JF);
                cmd.Parameters.AddWithValue("@medioDePago_842JF", factura.medioDePago_842JF);
                cmd.Parameters.AddWithValue("@nroPedido_842JF", factura.pedido_842JF.nroPedido_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEFactura_842JF> ObtenerTodas_842JF()
        {
            List<BEFactura_842JF> lista = new List<BEFactura_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Factura_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEFactura_842JF factura = new BEFactura_842JF(Convert.ToInt32(reader["nroFactura_842JF"]), Convert.ToDateTime(reader["fecha_842JF"]),
                                                                  reader["medioDePago_842JF"].ToString(), new BEPedido_842JF(Convert.ToInt32(reader["nroPedido_842JF"])));

                    lista.Add(factura);
                }
            }
            return lista;
        }
    }
}
