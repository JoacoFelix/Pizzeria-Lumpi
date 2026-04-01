using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{ 
    public class DALProducto_842JF : IDAL_842JF
    {
        public void Guardar_842JF(BEProducto_842JF producto)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO Producto_842JF (nombre_842JF,descripcion_842JF,precioCompra_842JF, cantidad_842JF,medida_842JF,disponible_842JF)
                                    VALUES (@nombre_842JF,@descripcion_842JF,@precioCompra_842JF,@cantidad_842JF,@medida_842JF,@disponible_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre_842JF", producto.nombre_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", producto.descripcion_842JF);
                cmd.Parameters.AddWithValue("@precioCompra_842JF", producto.precioCompra_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", producto.cantidad_842JF);
                cmd.Parameters.AddWithValue("@medida_842JF", producto.medida_842JF);
                cmd.Parameters.AddWithValue("@disponible_842JF", producto.disponible_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BEProducto_842JF> ObtenerTodos_842JF()
        {
            List<BEProducto_842JF> lista = new List<BEProducto_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Producto_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEProducto_842JF producto = new BEProducto_842JF(Convert.ToInt32(reader["codProducto_842JF"]), reader["nombre_842JF"].ToString(),
                                                                  reader["descripcion_842JF"].ToString(), Convert.ToDecimal(reader["precioCompra_842JF"]),
                                                                  Convert.ToInt32(reader["cantidad_842JF"]), reader["medida_842JF"].ToString(), Convert.ToBoolean(reader["disponible_842JF"]));

                    lista.Add(producto);
                }
            }
            return lista;
        }
        public void Modificar_842JF(BEProducto_842JF prod)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"UPDATE Producto_842JF 
                                    SET nombre_842JF = @nombre_842JF,
                                        descripcion_842JF = @descripcion_842JF,
                                        precioCompra_842JF = @precioCompra_842JF,
                                        medida_842JF = @medida_842JF,
                                        cantidad_842JF = @cantidad_842JF,
                                        disponible_842JF = @disponible_842JF
                                        WHERE codProducto_842JF = @codProducto_842JF";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre_842JF", prod.nombre_842JF);
                cmd.Parameters.AddWithValue("@descripcion_842JF", prod.descripcion_842JF);
                cmd.Parameters.AddWithValue("@precioCompra_842JF", prod.precioCompra_842JF);
                cmd.Parameters.AddWithValue("@medida_842JF", prod.medida_842JF);
                cmd.Parameters.AddWithValue("@cantidad_842JF", prod.cantidad_842JF);
                cmd.Parameters.AddWithValue("@disponible_842JF", prod.disponible_842JF);
                cmd.Parameters.AddWithValue("@codProducto_842JF", prod.codProducto_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
