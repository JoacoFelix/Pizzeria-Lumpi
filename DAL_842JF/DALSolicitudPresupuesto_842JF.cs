using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;


namespace DAL_842JF
{
    public class DALSolicitudPresupuesto_842JF : IDAL_842JF
    {
        public void Guardar_842JF(BESolicitudPresupuesto_842JF solicitud)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"INSERT INTO SolicitudPresupuesto_842JF (codProducto_842JF,CUIT_842JF, fecha_842JF)
                                    VALUES (@codProducto_842JF,@CUIT_842JF,@fecha_842JF)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codProducto_842JF", solicitud.producto_842JF.codProducto_842JF);
                cmd.Parameters.AddWithValue("@CUIT_842JF", solicitud.proveedor_842JF.CUIT_842JF);
                cmd.Parameters.AddWithValue("@fecha_842JF", solicitud.fecha_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<BESolicitudPresupuesto_842JF> ObtenerTodos_842JF()
        {
            List<BESolicitudPresupuesto_842JF> lista = new List<BESolicitudPresupuesto_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SolicitudPresupuesto_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BESolicitudPresupuesto_842JF solicitud = new BESolicitudPresupuesto_842JF(Convert.ToInt32(reader["codSolicitud_842JF"]), new BEProducto_842JF(Convert.ToInt32(reader["codProducto_842JF"])),
                                                                  new BEProveedor_842JF(reader["CUIT_842JF"].ToString()), Convert.ToDateTime(reader["fecha_842JF"]));

                    lista.Add(solicitud);
                }
            }
            return lista;
        }
        public void Eliminar_842JF(BESolicitudPresupuesto_842JF solicitud)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = @"DELETE FROM SolicitudPresupuesto_842JF 
                            WHERE codSolicitud_842JF = @codSolicitud_842JF";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@codSolicitud_842JF", solicitud.codSolicitudPresupuesto_842JF);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
