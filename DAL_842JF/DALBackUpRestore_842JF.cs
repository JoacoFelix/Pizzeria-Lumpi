
using Microsoft.Data.SqlClient;

namespace DAL_842JF
{
    public class DALBackUpRestore_842JF : IDAL_842JF
    {
        
        public void Backup_842JF(string rutaBackUp)
        {
            string nombre_842JF = $"Lumpi.BkUp_{DateTime.Now:ddMMyy_HHmm}.bak";
            string rutaCompleta_842JF = System.IO.Path.Combine(rutaBackUp, nombre_842JF);
            string command_842JF = $"BACKUP DATABASE SistemaPizzeriaFelixJoaquin TO DISK='{rutaCompleta_842JF}'";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(command_842JF, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Restore_842JF(string rutaBackUp)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                using (SqlCommand setMaster = new SqlCommand("USE master;", con))
                {
                    setMaster.ExecuteNonQuery();
                }

                using (SqlCommand setSingleUser = new SqlCommand("ALTER DATABASE SistemaPizzeriaFelixJoaquin SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", con))
                {
                    setSingleUser.ExecuteNonQuery();
                }

                string commandRestore = $"RESTORE DATABASE SistemaPizzeriaFelixJoaquin FROM DISK = '{rutaBackUp}' WITH REPLACE;";
                using (SqlCommand cmd = new SqlCommand(commandRestore, con))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand setMultiUser = new SqlCommand("ALTER DATABASE SistemaPizzeriaFelixJoaquin SET MULTI_USER;", con))
                {
                    setMultiUser.ExecuteNonQuery();
                }
            }
        }
    }
}
