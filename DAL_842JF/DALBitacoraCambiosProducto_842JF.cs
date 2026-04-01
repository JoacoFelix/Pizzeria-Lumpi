using BE_842JF;

using Org.BouncyCastle.Crypto.Agreement.JPake;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALBitacoraCambiosProducto_842JF: IDAL_842JF
    {
        public void Guardar_842JF(BEProducto_C_842JF productoC)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Producto_C_842JF (codProducto_842JF,fecha_842JF,nombre_842JF,cantidad_842JF,descripcion_842JF,precioCompra_842JF,medida_842JF,disponible_842JF,activo_842JF)
                                    VALUES (@codProducto_842JF,@fecha_842JF,@nombre_842JF,@cantidad_842JF,@descripcion_842JF,@precioCompra_842JF,@medida_842JF,@disponible_842JF,@activo_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", productoC.codProducto_842JF);
                cmd.Parameters.AddWithValue("@fecha_842JF", productoC.fecha_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", productoC.nombre_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", productoC.cantidad_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", productoC.descripcion_842JF);
                cmd.Parameters.AddWithValue("@precioCompra_842JF", productoC.precioCompra_842JF);
                cmd.Parameters.AddWithValue("@medida_842JF", productoC.medida_842JF);
                cmd.Parameters.AddWithValue("@disponible_842JF", productoC.disponible_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", productoC.activo_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEProducto_C_842JF> ObtenerTodos_842JF()
        {
            List<BEProducto_C_842JF> lista = new List<BEProducto_C_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Producto_C_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEProducto_C_842JF productoC = new BEProducto_C_842JF(Convert.ToInt32(reader["idCambio_842JF"]), Convert.ToInt32(reader["codProducto_842JF"]),
                                                                  Convert.ToDateTime(reader["fecha_842JF"]), reader["nombre_842JF"].ToString(),
                                                                  Convert.ToInt32(reader["cantidad_842JF"]), reader["descripcion_842JF"].ToString(), Convert.ToDecimal( reader["precioCompra_842JF"]), reader["medida_842JF"].ToString(), Convert.ToBoolean(reader["disponible_842JF"]), Convert.ToBoolean(reader["activo_842JF"]));

                    lista.Add(productoC);
                }
            }
            return lista;
        }
        public void Modificar_842JF(BEProducto_C_842JF prodC)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Producto_842JF 
                                    SET codProducto_842JF = @codProducto_842JF,
                                        fecha_842JF = @fecha_842JF,
                                        nombre_842JF = @nombre_842JF,
                                        cantidad_842JF = @cantidad_842JF,
                                        descripcion_842JF = @descripcion_842JF,                                      
                                        precioCompra_842JF = @precioCompra_842JF,                                        
                                        medida_842JF = @medida_842JF,
                                        disponible_842JF = @disponible_842JF,
                                        activo_842JF = @activo_842JF
                                        WHERE idCambio_842JF = @idCambio_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", prodC.codProducto_842JF);
                cmd.Parameters.AddWithValue("@fecha_842JF", prodC.fecha_842JF);
                cmd.Parameters.AddWithValue("@nombre_842JF", prodC.nombre_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", prodC.cantidad_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", prodC.descripcion_842JF);
                cmd.Parameters.AddWithValue("@precioCompra_842JF", prodC.precioCompra_842JF);
                cmd.Parameters.AddWithValue("@medida_842JF", prodC.medida_842JF);
                cmd.Parameters.AddWithValue("@disponible_842JF", prodC.disponible_842JF);
                cmd.Parameters.AddWithValue("@activo_842JF", prodC.activo_842JF);
                cmd.Parameters.AddWithValue("@idCambio_842JF", prodC.idCambio_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Activar_842JF(BEProducto_C_842JF prodC)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SP_ActivarRegistroYActualizarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCambio_842JF", prodC.idCambio_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
