using BE_842JF;
using Microsoft.Data.SqlClient;


namespace DAL_842JF
{
    public class DALPedido_842JF : IDAL_842JF
    {
        
        public void ConfirmarPedido_842JF(BEPedido_842JF pedido)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Pedido_842JF (DNI_842JF,estado_842JF,pago_842JF)
                                    VALUES (@DNI_842JF,@estado_842JF,@pago_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@DNI_842JF", pedido.cliente_842JF.DNI_842JF);
                cmd.Parameters.AddWithValue("@estado_842JF", pedido.estado_842JF);
                cmd.Parameters.AddWithValue("@pago_842JF", pedido.pago_842JF);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEPedido_842JF> ObtenerTodos_842JF()
        {
            List<BEPedido_842JF> lista = new List<BEPedido_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pedido_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEPedido_842JF pedido = new BEPedido_842JF(Convert.ToInt32(reader["nroPedido_842JF"]), new BECliente_842JF(reader["DNI_842JF"].ToString()), reader["estado_842JF"].ToString(), Convert.ToBoolean(reader["pago_842JF"]));

                    lista.Add(pedido);
                }
            }
            return lista;
        }
        public void ActualizarPedido_842JF(BEPedido_842JF pedido)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = "UPDATE Pedido_842JF SET pago_842JF = @pago_842JF, estado_842JF = @estado_842JF WHERE nroPedido_842JF = @nroPedido_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@pago_842JF", pedido.pago_842JF);
                cmd.Parameters.AddWithValue("@estado_842JF", pedido.estado_842JF);
                cmd.Parameters.AddWithValue("@nroPedido_842JF", pedido.nroPedido_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
