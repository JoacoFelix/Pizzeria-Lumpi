using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{
    public class DALProveedor_842JF : IDAL_842JF
    {
        public void Guardar_842JF(BEProveedor_842JF proveedor)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Proveedor_842JF (CUIT_842JF,nombre_842JF,telefono_842JF,estado_842JF,mail_842JF,direccion_842JF)
                                    VALUES (@CUIT_842JF,@nombre_842JF,@telefono_842JF,@estado_842JF,@mail_842JF,@direccion_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@CUIT_842JF", proveedor.CUIT_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", proveedor.nombre_842JF);
                cmd.Parameters.AddWithValue("@telefono_842JF", proveedor.telefono_842JF);
                cmd.Parameters.AddWithValue("@estado_842JF", proveedor.estado_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", proveedor.mail_842JF ?? "");
                cmd.Parameters.AddWithValue("@direccion_842JF", proveedor.direccion_842JF ?? "");

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Modificar_842JF(BEProveedor_842JF prov)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Proveedor_842JF 
                                    SET telefono_842JF = @telefono_842JF,
                                        estado_842JF = @estado_842JF,
                                        mail_842JF = @mail_842JF,
                                        direccion_842JF = @direccion_842JF
                                        WHERE CUIT_842JF = @CUIT_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@telefono_842JF", prov.telefono_842JF);
                cmd.Parameters.AddWithValue("@estado_842JF", prov.estado_842JF);
                cmd.Parameters.AddWithValue("@mail_842JF", prov.mail_842JF);
                cmd.Parameters.AddWithValue("@direccion_842JF", prov.direccion_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", prov.CUIT_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void GuardarProveedorProducto_842JF(BEProveedorProducto_842JF proveedorProd)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO ProveedorProducto_842JF (codProducto_842JF,CUIT_842JF)
                                    VALUES (@codProducto_842JF,@CUIT_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", proveedorProd.codProducto_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", proveedorProd.CUIT_842JF);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEProveedor_842JF> ObtenerTodos_842JF()
        {
            List<BEProveedor_842JF> lista = new List<BEProveedor_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedor_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                        BEProveedor_842JF proveedor = new BEProveedor_842JF(reader["CUIT_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToInt32(reader["telefono_842JF"]),
                                                                        Convert.ToBoolean(reader["estado_842JF"]), reader["mail_842JF"].ToString(), reader["direccion_842JF"].ToString());

                    lista.Add(proveedor);
                }
            }
            return lista;
        }
        public List<BEProveedorProducto_842JF> ObtenerTodosProveedorProducto_842JF()
        {
            List<BEProveedorProducto_842JF> lista = new List<BEProveedorProducto_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProveedorProducto_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEProveedorProducto_842JF proveedorProd = new BEProveedorProducto_842JF(Convert.ToInt32(reader["codProducto_842JF"]),reader["CUIT_842JF"].ToString());

                    lista.Add(proveedorProd);
                }
            }
            return lista;
        }
        public void EliminarProveedor_842JF(BEProveedor_842JF prov)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM Proveedor_842JF 
                            WHERE CUIT_842JF = @CUIT_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@CUIT_842JF", prov.CUIT_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarProveedorProducto_842JF(BEProveedorProducto_842JF proveedorProducto)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM ProveedorProducto_842JF 
                            WHERE codProducto_842JF = @codProducto_842JF AND CUIT_842JF = @CUIT_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", proveedorProducto.codProducto_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", proveedorProducto.CUIT_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarProvProducto_842JF(BEProveedor_842JF prov)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM ProveedorProducto_842JF 
                            WHERE CUIT_842JF = @CUIT_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@CUIT_842JF", prov.CUIT_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
