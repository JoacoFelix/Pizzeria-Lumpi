
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_842JF
{
    public class DALPermiso_842JF : IDAL_842JF
    {
       
        
        public List<Permiso_842JF> ObtenerTodos_842JF()
        {
            List<Permiso_842JF> lista = new List<Permiso_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Permiso_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Permiso_842JF perm = new Permiso_842JF(Convert.ToInt32(reader["codPermiso_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString());

                    lista.Add(perm);
                }
            }
            return lista;
        }
    }
}
