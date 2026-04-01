using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Numerics;
using BE_842JF;
using Servicios_842JF;

namespace DAL_842JF
{
    public class DALDV_842JF : IDAL_842JF
    {
        public string CalcularDigitoVerificadorHorizontal_842JF(BEDV_842JF dv)
        {
            BigInteger sumaTotal = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = $"SELECT * FROM {dv.nombreTabla_842JF}";
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object[] datos = new object[rdr.FieldCount];
                    rdr.GetValues(datos);
                    BigInteger sumaParcial = 0;
                    foreach (object o in datos)
                    {
                        string hex = Encriptador_842JF.Encriptar_842JF(o.ToString());
                        BigInteger num = BigInteger.Parse("00" + hex, NumberStyles.HexNumber);

                        sumaParcial += num;
                    }
                    string hex2 = Encriptador_842JF.Encriptar_842JF(sumaParcial.ToString());
                    sumaParcial = BigInteger.Parse("00" + hex2, NumberStyles.HexNumber);
                    sumaTotal += sumaParcial;
                }
            }
            return sumaTotal.ToString("X");
        }
        public string CalcularDigitoVerificadorVertical_842JF(BEDV_842JF dv)
        {
            BigInteger sumaTotal = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = $"SELECT * FROM {dv.nombreTabla_842JF}";
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<object[]> registros = new List<object[]>();
                while (rdr.Read())
                {
                    object[] fila = new object[rdr.FieldCount];
                    rdr.GetValues(fila);
                    registros.Add(fila);
                }
                rdr.Close();
                if (registros.Count > 0)
                {
                    for (int col = 0; col < registros[0].Length; col++)
                    {
                        BigInteger sumaColumna = 0;

                        foreach (var fila in registros)
                        {
                            string texto = fila[col]?.ToString() ?? "";
                            string hex = Encriptador_842JF.Encriptar_842JF(texto);

                            try
                            {
                                BigInteger valor = BigInteger.Parse("00" + hex, NumberStyles.HexNumber);
                                sumaColumna += valor;
                            }
                            catch
                            {

                            }
                        }
                        string hexCol = Encriptador_842JF.Encriptar_842JF(sumaColumna.ToString());
                        sumaColumna = BigInteger.Parse("00" + hexCol, NumberStyles.HexNumber);

                        sumaTotal += sumaColumna;
                    }
                }
            }
            return sumaTotal.ToString("X");
        }
        public void GuardarDigitoVerificador_842JF(BEDV_842JF dv)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string consulta = "SELECT COUNT(*) FROM DV_842JF WHERE nombreTabla_842JF = @nombre";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre", dv.nombreTabla_842JF);
                con.Open();
                int existe = (int)cmd.ExecuteScalar();
                if (existe > 0)
                {
                    string queryUpdate = @"UPDATE DV_842JF SET horizontal_842JF = @horizontal, vertical_842JF = @vertical WHERE nombreTabla_842JF = @nombre";

                    cmd = new SqlCommand(queryUpdate, con);
                    cmd.Parameters.AddWithValue("@horizontal", dv.horizontal_842JF);
                    cmd.Parameters.AddWithValue("@vertical", dv.vertical_842JF);
                    cmd.Parameters.AddWithValue("@nombre", dv.nombreTabla_842JF);

                    cmd.ExecuteNonQuery();
                }
            }

        }
        public List<BEDV_842JF> ObtenerTodos_842JF()
        {
            List<BEDV_842JF> lista = new List<BEDV_842JF>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DV_842JF", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEDV_842JF dv = new BEDV_842JF(reader["nombreTabla_842JF"].ToString(), reader["vertical_842JF"].ToString(),
                                                                  reader["horizontal_842JF"].ToString());

                    lista.Add(dv);
                }
            }
            return lista;
        }
       
    }
}
