using BE_842JF;

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALPedidoPizza_842JF : IDAL_842JF
    {
       
        public void ConfirmarPedido_842JF(BEPedidoPizza_842JF pedidopizza)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO PedidoPizza_842JF (nroPedido_842JF,codPizza_842JF,cantidad_842JF)
                                    VALUES (@nroPedido_842JF,@codPizza_842JF,@cantidad_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nroPedido_842JF", pedidopizza.nroPedido_842JF);
                cmd.Parameters.AddWithValue("@codPizza_842JF", pedidopizza.codPizza_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", pedidopizza.cantidad_842JF);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List <BEPedidoPizza_842JF> ObtenerTodos_842JF()
        {
            List<BEPedidoPizza_842JF> lista = new List<BEPedidoPizza_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PedidoPizza_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEPedidoPizza_842JF pedidoPizza = new BEPedidoPizza_842JF(Convert.ToInt32(reader["codPizza_842JF"]), Convert.ToInt32(reader["nroPedido_842JF"]), Convert.ToInt32(reader["cantidad_842JF"]));

                    lista.Add(pedidoPizza);
                }
            }
            return lista;
        }
    }
}
