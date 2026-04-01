using BE_842JF;
using Microsoft.Data.SqlClient;


namespace DAL_842JF
{
    public class DALPizza_842JF : IDAL_842JF
    {
        
        public List<BEPizza_842JF> ObtenerTodas_842JF()
        {
            List<BEPizza_842JF> lista = new List<BEPizza_842JF>();
            BEPizza_842JF pizza;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pizza_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nombre_842JF"].ToString() == "Muzzarella")
                    {
                        pizza = new BEPizzaMuzzarella_842JF(Convert.ToInt32(reader["codPizza_842JF"]),reader["descripcion_842JF"].ToString(),reader["nombre_842JF"].ToString(),Convert.ToDecimal(reader["precio_842JF"]));
                        
                    }
                    else if (reader["nombre_842JF"].ToString() == "Jamon")
                    {
                        pizza = new BEPizzaJamon_842JF(Convert.ToInt32(reader["codPizza_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToDecimal(reader["precio_842JF"]));
                        
                    }
                    else if (reader["nombre_842JF"].ToString() == "Jamon y Morron")
                    {
                        pizza = new BEPizzaJamonyMorron_842JF(Convert.ToInt32(reader["codPizza_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToDecimal(reader["precio_842JF"]));

                    }
                    else if (reader["nombre_842JF"].ToString() == "Jamon crudo y rucula")
                    {
                        pizza = new BEPizzaJamonCrudoyRucula_842JF(Convert.ToInt32(reader["codPizza_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToDecimal(reader["precio_842JF"]));

                    }
                    else if (reader["nombre_842JF"].ToString() == "Fugazzetta")
                    {
                        pizza = new BEPizzaFugazzetta_842JF(Convert.ToInt32(reader["codPizza_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToDecimal(reader["precio_842JF"]));

                    }
                    else
                    {
                        pizza = new BEPizzaEspecial_842JF(Convert.ToInt32(reader["codPizza_842JF"]), reader["descripcion_842JF"].ToString(), reader["nombre_842JF"].ToString(), Convert.ToDecimal(reader["precio_842JF"]));
                    }
                    lista.Add(pizza);
                }
            }
            return lista;
        }
    }
}
